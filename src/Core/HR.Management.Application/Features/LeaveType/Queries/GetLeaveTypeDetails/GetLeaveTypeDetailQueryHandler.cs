using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDetailDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailQuery request,
            CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.id);

            // Verify that record exists
            if (leaveType == null)
                throw new NotFoundException(nameof(Domain.LeaveType), request.id);

            var data = _mapper.Map<LeaveTypeDetailDto>(leaveType);

            return data;
        }
    }
}