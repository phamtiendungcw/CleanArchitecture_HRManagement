using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain;
using Moq;

namespace HR.Management.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 43,
                    Name = "Test sick"
                },
                new LeaveType
                {
                    Id = 3,
                    DefaultDays = 3,
                    Name = "Test maternity"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

            return mockRepo;
        }
    }
}