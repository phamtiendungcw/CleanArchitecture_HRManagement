using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails
{
    public class LeaveRequestDetailDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeListDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public DateTime? DateAction { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}