using MediatR;

namespace HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public string Sting { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
