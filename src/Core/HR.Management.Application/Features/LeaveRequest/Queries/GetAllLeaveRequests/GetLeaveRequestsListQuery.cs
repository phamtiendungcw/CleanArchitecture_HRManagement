using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public record GetLeaveRequestsListQuery : IRequest<List<LeaveRequestListDto>>;
}