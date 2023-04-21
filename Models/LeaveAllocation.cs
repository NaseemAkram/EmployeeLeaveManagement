using EmployeeLeaveManagement.View_Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLeaveManagement.Models
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
