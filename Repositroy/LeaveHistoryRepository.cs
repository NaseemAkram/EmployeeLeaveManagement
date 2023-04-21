using EmployeeLeaveManagement.Contracts;
using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Repositroy
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {

        private readonly ApplicationContext _context;

        public LeaveHistoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(LeaveHistory entry)
        {
            _context.LeaveHistories.Add(entry);
            return Save();
        }

        public bool Delete(LeaveHistory entry)
        {
            _context.LeaveHistories.Remove(entry);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var LeaveHistories = _context.LeaveHistories.ToList();
            return LeaveHistories;
        }

        public LeaveHistory FindById(int id)
        {
            var LeaveHistories = _context.LeaveHistories.Find(id);
            return LeaveHistories;
        }

        public bool IsExist(int id)
        {
            var result = _context.LeaveHistories.Any(g => g.Id == id);
            return result;
        }

        public bool Save()
        {
            var saveresult = _context.SaveChanges();
            return saveresult > 0;
        }

        public bool Update(LeaveHistory entry)
        {
            _context.LeaveHistories.Update(entry);
            return Save();
        }
    }
}
