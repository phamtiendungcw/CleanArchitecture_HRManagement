namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class LeaveAllocationDetailDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public Domain.LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}