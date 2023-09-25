using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class LeaveAllocationDetailDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeListDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}