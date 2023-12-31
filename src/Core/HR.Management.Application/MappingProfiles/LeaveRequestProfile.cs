﻿using AutoMapper;
using HR.Management.Application.Features.LeaveRequest.Command.CreateLeaveRequest;
using HR.Management.Application.Features.LeaveRequest.Command.UpdateLeaveRequest;
using HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;
using HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.Management.Domain;

namespace HR.Management.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}