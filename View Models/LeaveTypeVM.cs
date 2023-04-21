using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagement.View_Models
{
    public class LeaveTypeVM
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Created Date")]
        public DateTime? DateCreated { get; set; }
    }



}
