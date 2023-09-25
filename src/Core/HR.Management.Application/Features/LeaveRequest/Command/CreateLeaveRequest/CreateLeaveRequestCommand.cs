using HR.Management.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<int>
    {
        public string? RequestComments { get; set; } = string.Empty;
    }
}