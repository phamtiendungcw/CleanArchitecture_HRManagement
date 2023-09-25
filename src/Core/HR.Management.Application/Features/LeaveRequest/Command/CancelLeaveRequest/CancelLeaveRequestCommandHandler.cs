using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CancelLeaveRequestCommandHandler> _logger;

        public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IEmailSender emailSender, IAppLogger<CancelLeaveRequestCommandHandler> logger)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
                throw new NotFoundException(nameof(leaveRequest), request.Id);

            leaveRequest.Canceled = true;

            // If already approved, re-evaluate the employee's allocations for the leave type

            // Send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been cancelled successfully.",
                    Subject = "Leave Request Cancelled"
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