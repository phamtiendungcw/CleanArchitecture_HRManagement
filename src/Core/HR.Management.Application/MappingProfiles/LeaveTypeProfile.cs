using AutoMapper;
using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.Management.Domain;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>();
        }
    }
}
