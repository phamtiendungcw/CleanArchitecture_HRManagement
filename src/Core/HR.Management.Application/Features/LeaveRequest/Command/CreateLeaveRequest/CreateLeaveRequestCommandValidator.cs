using FluentValidation;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveRequest.Shared;

namespace HR.Management.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
        }
    }
}