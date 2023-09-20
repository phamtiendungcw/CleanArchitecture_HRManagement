using MediatR;

namespace HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailsQuery(int id) : IRequest<LeaveTypeDetailDto>;
}
