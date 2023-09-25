using AutoMapper;
using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IEmailSender emailSender,
            IAppLogger<UpdateLeaveRequestCommandHandler> logger)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            var validator = new UpdateLeaveRequestCommandValidator(_leaveTypeRepository, _leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Request", validationResult);

            _mapper.Map(request, leaveRequest);

            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            try
            {
                var email = new EmailMessage()
                {
                    To = string.Empty, // Get email from employee record
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                           $"has been update successfully.",
                    Subject = "Leave request submitted"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
                _logger.LogWaring(e.Message);
            }

            return Unit.Value;
        }
    }
}