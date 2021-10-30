using System.Web.Mvc;

namespace CsHealthcare.web.Areas.Microbiology
{
    public class MicrobiologyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Microbiology";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Microbiology_default",
                "Microbiology/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}