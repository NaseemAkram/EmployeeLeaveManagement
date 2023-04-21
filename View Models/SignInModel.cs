using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace EmployeeLeaveManagement.View_Models
{
    public class SignInModel
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool Rememberme { get; set; }
    }
}
