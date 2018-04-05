using System;
using System.ComponentModel.DataAnnotations;
using ITechArt.DrawIoSharing.Resources;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorUserNameRequired), ErrorMessage = null)]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.UserName))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorEmailRequired), ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorInvalidEmailAddress), ErrorMessage = null)]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.Email))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorPasswordRequired), ErrorMessage = null)]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.Password))]

        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorPasswordNotConfirmed), ErrorMessage = null)]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.PasswordConfirmation))]
        public string PasswordConfirmation { get; set; }
    }
}