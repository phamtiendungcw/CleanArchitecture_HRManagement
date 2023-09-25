using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.CancelLeaveRequest
{
    public class CancelLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
