using AutoMapper;
using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreateLeaveRequestCommand> _logger;

        public CreateLeaveRequestCommandHandler(ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender emailSender,
            IAppLogger<CreateLeaveRequestCommand> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Request", validationResult);

            // Get requesting employee's id

            // Check on employee's allocation

            // If allocations aren't enough, return validation error with message

            // Create leave request
            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
            await _leaveRequestRepository.CreateAsync(leaveRequest);

            // Send Confirmation email
            try
            {
                var email = new EmailMessage()
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                           $"has been submitted successfully.",
                    Subject = "Leave request submitted"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
                _logger.LogWaring(e.Message);
            }

            return leaveRequest.Id;
        }
    }
}