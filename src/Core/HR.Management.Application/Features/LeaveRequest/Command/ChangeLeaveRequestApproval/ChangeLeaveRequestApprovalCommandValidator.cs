using FluentValidation;

namespace HR.Management.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalCommandValidator()
        {
            RuleFor(x => x.Approved)
                .NotNull()
                .WithMessage("{PropertyName} status cannot be null");
        }
    }
}
