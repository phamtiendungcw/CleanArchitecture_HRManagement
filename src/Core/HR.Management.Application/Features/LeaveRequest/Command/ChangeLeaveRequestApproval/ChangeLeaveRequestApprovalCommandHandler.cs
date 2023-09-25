using AutoMapper;
using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<ChangeLeaveRequestApprovalCommandHandler> _logger;

        public ChangeLeaveRequestApprovalCommandHandler(ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender,
            IAppLogger<ChangeLeaveRequestApprovalCommandHandler> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
                throw new NotFoundException(nameof(leaveRequest), request.Id);

            leaveRequest.Approved = request.Approved;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            // If request is approved, get and update the employee's allocations

            // send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body =
                        $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been updated.",
                    Subject = "Leave Request Approval Status Updated"
                };
                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
                // log error
                _logger.LogWaring(e.Message);
            }

            return Unit.Value;
        }
    }
}