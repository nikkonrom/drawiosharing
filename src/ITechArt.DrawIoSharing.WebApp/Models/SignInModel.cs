using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class SignInModel
    {
        [HiddenInput]
        public string ReturnUrl { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}