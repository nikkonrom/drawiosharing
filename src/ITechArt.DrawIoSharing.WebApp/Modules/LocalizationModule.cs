using System.Web;
using ITechArt.DrawIoSharing.WebApp.Localization;
using Ninject;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    public class LocalizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                IKernel kernel = new StandardKernel(new DrawIoSharingNinjectModule());
                var cultureOptions = kernel.Get<CultureOptions>();
                cultureOptions.SetUpCulture();
                HttpContext.Current.Items.Add("ActualLanguageName", cultureOptions.GetLocalizedNameOfActualLanguage());
            };
        }

        public void Dispose()
        {

        }
    }
}