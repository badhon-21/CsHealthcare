using System.Web.Mvc;

namespace CsHealthcare.web.Areas.Physiotherapy
{
    public class PhysiotherapyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Physiotherapy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Physiotherapy_default",
                "Physiotherapy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}