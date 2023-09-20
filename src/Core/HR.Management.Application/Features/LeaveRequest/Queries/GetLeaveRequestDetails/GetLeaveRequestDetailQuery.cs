using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails
{
    public record GetLeaveRequestDetailQuery(int id) : IRequest<LeaveRequestDetailDto>;
}