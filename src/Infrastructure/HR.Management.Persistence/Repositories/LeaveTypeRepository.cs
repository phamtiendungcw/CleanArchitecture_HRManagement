using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain;
using HR.Management.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.Management.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(x => x.Name == name) == false;
        }
    }
}