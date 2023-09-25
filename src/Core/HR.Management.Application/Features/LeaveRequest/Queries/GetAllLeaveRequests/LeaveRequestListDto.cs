using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests
{
    public class LeaveRequestListDto
    {
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeListDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}