using FluentValidation;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveRequest.Shared;

namespace HR.Management.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;

            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveRequestMustExist)
                .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken arg2)
        {
            var leaveAllocation = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveAllocation != null;
        }
    }
}