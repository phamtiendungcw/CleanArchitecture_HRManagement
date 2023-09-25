using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public class GetLeaveRequestsListQueryHandler : IRequestHandler<GetLeaveRequestsListQuery, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestsListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestsListQuery request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            var data = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);

            return data;
        }
    }
}