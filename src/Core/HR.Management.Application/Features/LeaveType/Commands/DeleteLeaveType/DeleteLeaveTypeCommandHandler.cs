using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Retrieve domain entity obj
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Verify that record exists
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            // Remove form database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // Return record id
            return Unit.Value;
        }
    }
}
