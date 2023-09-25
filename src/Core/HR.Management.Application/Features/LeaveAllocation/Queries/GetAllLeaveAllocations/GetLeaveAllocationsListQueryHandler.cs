using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public class GetLeaveAllocationsListQueryHandler : IRequestHandler<GetLeaveAllocationsListQuery, List<LeaveAllocationListDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationsListQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationListDto>> Handle(GetLeaveAllocationsListQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();

            var data = _mapper.Map<List<LeaveAllocationListDto>>(leaveAllocations);

            return data;
        }
    }
}