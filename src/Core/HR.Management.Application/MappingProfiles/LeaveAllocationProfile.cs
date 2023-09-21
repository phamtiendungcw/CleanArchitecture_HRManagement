using AutoMapper;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.Management.Domain;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>();
            CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
        }
    }
}
