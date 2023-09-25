using AutoMapper;
using HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.Management.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.Management.Domain;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeListDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}