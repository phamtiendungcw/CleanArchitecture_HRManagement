using MediatR;

namespace HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailQuery(int id) : IRequest<LeaveTypeDetailDto>;
}