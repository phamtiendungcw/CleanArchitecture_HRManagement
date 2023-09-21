using AutoMapper;
using HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.Management.Domain;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailDto>();
        }
    }
}
