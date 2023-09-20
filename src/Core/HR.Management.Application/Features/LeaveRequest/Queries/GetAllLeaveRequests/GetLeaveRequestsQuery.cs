using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public record GetLeaveRequestsQuery : IRequest<List<LeaveRequestDto>>;
}