using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails
{
    public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.id);

            if (leaveRequest == null)
                throw new NotFoundException(nameof(Domain.LeaveRequest), request.id);

            var data = _mapper.Map<LeaveRequestDetailDto>(leaveRequest);

            return data;
        }
    }
}