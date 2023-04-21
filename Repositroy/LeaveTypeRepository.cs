using EmployeeLeaveManagement.Contracts;
using EmployeeLeaveManagement.Data;
using EmployeeLeaveManagement.Models;

namespace EmployeeLeaveManagement.Repositroy
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {

        private readonly ApplicationContext _db;

        public LeaveTypeRepository(ApplicationContext context)
        {
            _db = context;
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            var result = _db.LeaveTypes.Any(g => g.Id == id);
            return result;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
