using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public record GetLeaveAllocationsListQuery : IRequest<List<LeaveAllocationListDto>>;
}