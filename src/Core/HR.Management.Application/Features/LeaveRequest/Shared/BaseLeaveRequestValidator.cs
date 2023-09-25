using FluentValidation;
using HR.Management.Application.Contracts.Persistence;

namespace HR.Management.Application.Features.LeaveRequest.Shared
{
    public class BaseLeaveRequestValidator : AbstractValidator<BaseLeaveRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public BaseLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate)
                .WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate)
                .WithMessage("{PropertyName} must be after {ComparisonValue}");
            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("{PropertyName} does not exits");
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}
