using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public record GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>;
}