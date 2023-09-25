using AutoMapper;
using HR.Management.Application.Features.LeaveAllocation.Command.CreateLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Command.UpdateLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.Management.Domain;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationListDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}