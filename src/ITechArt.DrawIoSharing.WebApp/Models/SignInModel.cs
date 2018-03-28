using System.ComponentModel.DataAnnotations;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class SignInModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}