using EmployeeLeaveManagement.Contracts;
using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Repositroy
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {

        private readonly ApplicationContext _context;

        public LeaveAllocationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(LeaveAllocation entry)
        {
            _context.LeaveAllocations.Add(entry);
            return Save();
        }

        public bool Delete(LeaveAllocation entry)
        {
            _context.LeaveAllocations.Remove(entry);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var LeaveAllocation = _context.LeaveAllocations.ToList();
            return LeaveAllocation;
        }

        public LeaveAllocation FindById(int id)
        {
            var LeaveAllocation = _context.LeaveAllocations.Find(id);
            return LeaveAllocation;
        }

        public bool IsExist(int id)
        {
            var result = _context.LeaveAllocations.Any(g => g.Id == id);
            return result;
        }

        public bool Save()
        {
            var saveresult = _context.SaveChanges();
            return saveresult > 0;
        }

        public bool Update(LeaveAllocation entry)
        {
            _context.LeaveAllocations.Update(entry);
            return Save();
        }
    }
}
