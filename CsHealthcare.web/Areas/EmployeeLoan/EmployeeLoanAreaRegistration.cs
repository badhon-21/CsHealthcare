using System.Web.Mvc;

namespace CsHealthcare.web.Areas.EmployeeLoan
{
    public class EmployeeLoanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EmployeeLoan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EmployeeLoan_default",
                "EmployeeLoan/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}