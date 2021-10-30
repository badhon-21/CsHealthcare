using System.Web.Mvc;

namespace CsHealthcare.web.Areas.MedicineCorner
{
    public class MedicineCornerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MedicineCorner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MedicineCorner_default",
                "MedicineCorner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}