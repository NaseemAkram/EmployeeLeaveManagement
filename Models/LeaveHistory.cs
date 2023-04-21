using EmployeeLeaveManagement.View_Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeLeaveManagement.Models
{
    public class LeaveHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        [AllowNull]

        public string? EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveTypeVM LeaveType { get; set; }
        public string? LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        [ForeignKey("ApprovedById")]
        public Employee ApprovedBy { get; set; }
        public int ApprovedById { get; set; }
    }
}
