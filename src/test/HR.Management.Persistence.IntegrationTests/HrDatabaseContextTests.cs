using HR.Management.Domain;
using HR.Management.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.Management.Persistence.IntegrationTests
{
    public class HrDatabaseContextTests
    {
        private HRDatabaseContext _hrDatabaseContext;

        public HrDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HRDatabaseContext>()
                .UseInMemoryDatabase(new Guid().ToString()).Options;
            _hrDatabaseContext = new HRDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var leaveType = new LeaveType()
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            // Assert
            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var leaveType = new LeaveType()
            {
                Id = 3,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            // Assert
            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}