using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
    }
}
