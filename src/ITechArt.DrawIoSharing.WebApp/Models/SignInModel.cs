using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ITechArt.DrawIoSharing.Resources;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class SignInModel
    {
        [HiddenInput]
        public string ReturnUrl { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorUserNameRequired))]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.UserName))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.ErrorPasswordRequired))]
        [Display(ResourceType = typeof(Resource), Name = nameof(Resource.Password))]
        public string Password { get; set; }
    }
}