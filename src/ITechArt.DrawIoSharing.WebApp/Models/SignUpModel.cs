using System.ComponentModel.DataAnnotations;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Confirm password doesn't match, Type again !"), Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}