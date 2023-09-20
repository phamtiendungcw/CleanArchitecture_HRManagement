using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid LeaveType", validationResult);

            // Convert to domain entity obj
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            // Add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            //return id
            return leaveTypeToCreate.Id;
        }
    }
}
