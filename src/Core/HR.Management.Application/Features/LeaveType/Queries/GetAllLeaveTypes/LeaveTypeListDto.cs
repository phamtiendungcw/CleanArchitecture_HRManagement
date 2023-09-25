namespace HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class LeaveTypeListDto
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}