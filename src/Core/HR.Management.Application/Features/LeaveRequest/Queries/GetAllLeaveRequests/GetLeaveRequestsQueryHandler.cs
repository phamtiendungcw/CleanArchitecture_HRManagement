using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetAsync();
            var data = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);

            return data;
        }
    }
}