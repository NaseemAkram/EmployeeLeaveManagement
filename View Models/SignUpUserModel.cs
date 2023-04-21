using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace EmployeeLeaveManagement.Models
{
    public class SignUpUserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter Strong Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

    }
}
