using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "The field {0} is Required")]
        [EmailAddress(ErrorMessage = "Field {0} is in invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is Required")]
        [StringLength(100, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
