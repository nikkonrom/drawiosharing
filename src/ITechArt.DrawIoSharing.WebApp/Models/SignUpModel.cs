using System.ComponentModel.DataAnnotations;
using ITechArt.DrawIoSharing.Resources;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorUserNameRequired))]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.UserName))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorEmailRequired))]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.Email))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorInvalidEmailAddress))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorPasswordRequired))]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.Password))]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorPasswordNotConfirmed))]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.PasswordConfirmation))]
        public string PasswordConfirmation { get; set; }
    }
}