using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public record GetLeaveAllocationDetailQuery(int id) : IRequest<LeaveAllocationDetailDto>;
}