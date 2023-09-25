using HR.Management.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public int Id { get; set; }
        public string RequestComments { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
    }
}