using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagement.Models
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
