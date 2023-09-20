namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public class LeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Domain.LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
        public string RequestingEmployeeId { get; set; } = string.Empty;
    }
}