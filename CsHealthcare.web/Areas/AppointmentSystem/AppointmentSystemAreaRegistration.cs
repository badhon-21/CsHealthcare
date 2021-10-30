using System.Web.Mvc;

namespace CsHealthcare.web.Areas.AppointmentSystem
{
    public class AppointmentSystemAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AppointmentSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AppointmentSystem_default",
                "AppointmentSystem/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}