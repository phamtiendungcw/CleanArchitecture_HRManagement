using AutoMapper;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistence;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesListQueryHandler : IRequestHandler<GetLeaveTypesListQuery, List<LeaveTypeListDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesListQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetLeaveTypesListQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper,
            IAppLogger<GetLeaveTypesListQueryHandler> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<LeaveTypeListDto>> Handle(GetLeaveTypesListQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // Convert data obj to DTO obj
            var data = _mapper.Map<List<LeaveTypeListDto>>(leaveTypes);

            // Return list of DTO obj
            _logger.LogInformation("Leave types were retrieved successfully.");
            return data;
        }
    }
}