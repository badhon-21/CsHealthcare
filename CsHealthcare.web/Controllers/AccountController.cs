using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Cs.Utility;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Filters;
using CsHealthcare.Services;
using CsHealthcare.Utility;
using CsHealthcare.ViewModel.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CsHealthcare.web.Models;

namespace CsHealthcare.web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext context;
        public AccountController()
        {
            context = new ApplicationDbContext();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                  //  returnUrl = Url.Action("Index", "Home", new { area = "" });
                    var homeurl = Url.Action("Index", "Home", new { area = "" });
                    SessionManager.DashBoard = homeurl;
                    if (returnUrl != null)
                        if (homeurl != returnUrl)
                        {
                            return RedirectToLocal(returnUrl);
                        }

                    var user = await UserManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        if (UserManager.IsInRole(user.Id, "Administrator"))
                        {
                            //SessionManager.UserRole = "Administrator";
                            returnUrl = Url.Action("Index", "AdministrativeDashBoard");
                            SessionManager.DashBoard = returnUrl;
                        }
                        else if (UserManager.IsInRole(user.Id, "Doctor"))
                        {
                            //SessionManager.UserRole = "MsAdmin";
                            returnUrl = Url.Action("Index", "DoctorDashBoard");
                            SessionManager.DashBoard = returnUrl;
                        }
                        else if (UserManager.IsInRole(user.Id, "Application Admin"))
                        {
                            //SessionManager.UserRole = "Application Admin";
                            returnUrl = Url.Action("Index", "LabTechnicianDashBoard");

                            AppServices appServices = new AppServices();
                            //SessionManager.CompanyId = appServices.AppUserRepository.Get().Where(w => w.APPLICATION_USER_ID == user.Id).FirstOrDefault().CI_ID;
                          //  var val = appServices.AppUserRepository.FindBy(a => a.APPLICATION_USER_ID == user.Id).FirstOrDefault();
                            //SessionManager.PharmacyModule = val.PHARMACY;
                            //SessionManager.AppointmentSystemModule = val.APPOINTMENT;
                            //SessionManager.PatientManagementModule = val.PATIENT_MANAGEMENT;
                            //SessionManager.PathologyModule = val.PATHOLOGY;
                            SessionManager.DashBoard = returnUrl;
                        }
                        else if (UserManager.IsInRole(user.Id, "Patient Appointment"))
                        {
                            //SessionManager.UserRole = "Patient Appointment";
                            returnUrl = Url.Action("Index", "NurseDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.CompanyId = appServices.AppPatientManagementUserRepository.Get().Where(w=>w.APPLICATION_USER_ID==user.Id).FirstOrDefault().CI_ID;
                        }

                        else if (UserManager.IsInRole(user.Id, "Front Desk Officer"))
                        {
                            //SessionManager.UserRole = "Patient Appointment";
                            returnUrl = Url.Action("Index", "OPDDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.CompanyId = appServices.AppPatientManagementUserRepository.Get().Where(w=>w.APPLICATION_USER_ID==user.Id).FirstOrDefault().CI_ID;
                        }

                        else if (UserManager.IsInRole(user.Id, "Patient History"))
                        {
                            //SessionManager.UserRole = "Patient History";
                            returnUrl = Url.Action("Index", "PatientDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.CompanyId = appServices.AppPatientManagementUserRepository.Get().Where(w => w.APPLICATION_USER_ID == user.Id).FirstOrDefault().CI_ID;
                        }
                        else if (UserManager.IsInRole(user.Id, "Patient History"))
                        {
                            //SessionManager.UserRole = "Patient History";
                            returnUrl = Url.Action("Index", "PatientDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.CompanyId = appServices.AppPatientManagementUserRepository.Get().Where(w => w.APPLICATION_USER_ID == user.Id).FirstOrDefault().CI_ID;
                        }
                        else if (UserManager.IsInRole(user.Id, "Patient Accounts"))
                        {
                            //SessionManager.UserRole = "Patient Accounts";
                            returnUrl = Url.Action("Index", "PatientDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.CompanyId = appServices.AppPatientManagementUserRepository.Get().Where(w => w.APPLICATION_USER_ID == user.Id).FirstOrDefault().CI_ID;
                        }
                        else if (UserManager.IsInRole(user.Id, "Patient Prescription"))
                        {
                            //SessionManager.UserRole = "Patient Prescription";
                            returnUrl = Url.Action("Index", "PatientDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.DoctorId = appServices.AppPatientManagementUserRepository.Get().Where(w => w.APPLICATION_USER_ID == user.Id).FirstOrDefault().DI_ID;
                        }
                        else if (UserManager.IsInRole(user.Id, "Pharmacy Accounts"))
                        {
                            //SessionManager.UserRole = "Patient Prescription";
                            returnUrl = Url.Action("Index", "PharmacistDashBoard");
                            SessionManager.DashBoard = returnUrl;

                            AppServices appServices = new AppServices();
                            //SessionManager.DoctorId = appServices.AppPatientManagementUserRepository.Get().Where(w => w.APPLICATION_USER_ID == user.Id).FirstOrDefault().DI_ID;
                        }
                    }
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }


        public ActionResult LoadUser()
        {
            var service = new AppServices();
            string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
            Modelfactory modelFactory = new Modelfactory();

            List<UserList> userList = new List<UserList>();

            service.AppPatientManagementUserRepository.GetData(w => w.HospitalId == profileId)
                .ToList()
                .ForEach(fe => userList.Add(new UserList
                {
                    ID = fe.ApplicationUserId,
                    Name = (fe.EmployeeId == "0") ? fe.DoctorInformation.Name : fe.Employee.FirstName,
                    Username = fe.AspNetUser.UserName,
                    Type = "Patient Management"
                }));

            service.AppMedicineCornerUserRepository.GetData(w => w.HospitalId == profileId)
                .ToList()
                .ForEach(fe => userList.Add(new UserList
                {
                    ID = fe.ApplicationUserId,
                    Name = fe.Employee.FirstName,
                    Username = fe.AspNetUser.UserName,
                    Type = "Medicine Corner"
                }));

            service.AppAppointmentSystemUserRepository.GetData(w => w.HospitalId == profileId)
                .ToList()
                .ForEach(fe => userList.Add(new UserList
                {
                    ID = fe.ApplicationUserId,
                    Name = fe.Employee.FirstName,
                    Username = fe.AspNetUser.UserName,
                    Type = "Appointment System"
                }));

            return PartialView("UserList", userList);
        }

        [AuthLog(Roles = "Administrator, MsAdmin, Application Admin")]
        [AllowAnonymous]
        public ActionResult CreateSolutionUser()
        {
            var service = new AppServices();

            var value = context.Roles.Where(x => x.Name != "MsAdmin" && x.Name != "Administrator" && x.Name != "Application Admin").ToList();

            if (((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Appointment.Module"]).Value == OperationStatus.NO)
                value.RemoveAll(r => r.Name == "Patient Appointment");

            if (((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Patient.Management.Module"]).Value == OperationStatus.NO)
            {
                value.RemoveAll(r => r.Name == "Patient History");
                value.RemoveAll(r => r.Name == "Patient Prescription");
                value.RemoveAll(r => r.Name == "Patient Accounts");
            }

            if (((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Pharmacy.Module"]).Value == OperationStatus.NO)
            {
                value.RemoveAll(r => r.Name == "Purchase");
                value.RemoveAll(r => r.Name == "Inventory");
                value.RemoveAll(r => r.Name == "Sales");
                value.RemoveAll(r => r.Name == "Pharmacy Accounts");
            }

            ViewBag.RoleName = new SelectList(value.OrderBy(ob => ob.Name).ToList(), "Name", "Name");
            string profileId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
            ViewBag.DI_ID = new SelectList(service.DoctorInformationRepository.Get().Where(w => w.Id != "0" && w.HospitalId == profileId), "Id", "Name");
            ViewBag.EI_ID = new SelectList(service.EmployeeInfoRepository.Get().Where(w => w.Id != "0" /*&& w.CompanyId == profileId*/), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Administrator, MsAdmin, Application Admin")]
        public async Task<ActionResult> CreateSolutionUser(RegisterViewModel model)
        {
            var service = new AppServices();
            string doctorId = "";
            string employeeId = "";
            string emailAddress = "";
            if (model.RoleName == "Patient Prescription"||model.RoleName == "Doctor" )
            {
                doctorId = Request["DI_ID"];
                employeeId = "1";
                emailAddress =
                    service.DoctorInformationRepository.Get().Where(w => w.Id == doctorId).FirstOrDefault().Email;
            }
            else if (model.RoleName == "Patient Appointment" || model.RoleName == "Patient Accounts" || model.RoleName == "Patient History"|| model.RoleName == "Front Desk Officer" || model.RoleName == "Nurse" || model.RoleName == "Pharmacy Accounts")
            {
                doctorId = "1";
                employeeId = Request["EI_ID"];
                emailAddress =
                    service.EmployeeInfoRepository.Get().Where(w => w.Id == employeeId).FirstOrDefault().Email;
            }
            else if (model.RoleName == "Purchase" || model.RoleName == "Inventory" || model.RoleName == "Sales")
            {
                doctorId = "1";
                employeeId = Request["EI_ID"];
                emailAddress =
                    service.EmployeeInfoRepository.Get().Where(w => w.Id == employeeId).FirstOrDefault().Email;
            }
            //if (emailAddress == "" || emailAddress == null)
            //    emailAddress = "mehedi1983@gmail.com";

            var user = new ApplicationUser { UserName = model.UserName, Email = emailAddress };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                try
                {
                    await this.UserManager.AddToRoleAsync(user.Id, model.RoleName);
                    UserManager.AddClaim(user.Id, new Claim(ConfigurationManager.AppSettings["Profile.Id"], ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value));
                    if (model.RoleName == "Patient Prescription" || model.RoleName == "Front Desk Officer" || model.RoleName == "Doctor" || model.RoleName == "Patient Appointment" || model.RoleName == "Patient Accounts" || model.RoleName == "Patient History")
                    {
                        if (doctorId != "1")
                            UserManager.AddClaim(user.Id, new Claim(ConfigurationManager.AppSettings["Doctor.Id"], doctorId));

                        AppPatientManagementUser appPatientManagementUser = new AppPatientManagementUser();
                        appPatientManagementUser.ApplicationUserId = user.Id;
                        appPatientManagementUser.HospitalId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                        appPatientManagementUser.DoctorId = doctorId;
                        appPatientManagementUser.EmployeeId = employeeId;
                        appPatientManagementUser.CreatedDate = DateTime.Now;
                        service.AppPatientManagementUserRepository.Insert(appPatientManagementUser);
                        service.Commit();
                    }
                    else if (model.RoleName == "Purchase" || model.RoleName == "Inventory" || model.RoleName == "Sales")
                    {
                        AppMedicineCornerUser appMedicineCornerUser = new AppMedicineCornerUser();
                        appMedicineCornerUser.ApplicationUserId = user.Id;
                        appMedicineCornerUser.HospitalId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                        appMedicineCornerUser.EmployeeId = employeeId;
                        service.AppMedicineCornerUserRepository.Insert(appMedicineCornerUser);
                        service.Commit();
                    }
                 //   else
                 //   { 
                 //   AppUser appMedicineCornerUser = new AppUser();
                 //   appMedicineCornerUser.ApplicationUserId = user.Id;
                 //   appMedicineCornerUser.HospitalId = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(ConfigurationManager.AppSettings["Profile.Id"]).Value;
                 ////   appMedicineCornerUser.EmployeeId = employeeId;
                 //   service.AppUserRepository.Insert(appMedicineCornerUser);
                 //   service.Commit();
                 //        }

                }
                catch (Exception ex)
                {
                    var patientUser = service.AppPatientManagementUserRepository.GetData(gd => gd.ApplicationUserId == user.Id).FirstOrDefault();
                    var medicineUser = service.AppMedicineCornerUserRepository.GetData(gd => gd.ApplicationUserId == user.Id).FirstOrDefault();

                    if (patientUser != null)
                    {
                        service.AppPatientManagementUserRepository.DeleteById(patientUser.Id);
                        service.Commit();
                    }

                    if (medicineUser != null)
                    {
                        service.AppMedicineCornerUserRepository.DeleteById(patientUser.Id);
                        service.Commit();
                    }
                    var v = await UserManager.DeleteAsync(user);
                }

                return RedirectToAction("UserIndex", "Account");
            }
            AddErrors(result);

            return View(model);
        }
        public ActionResult UserIndex()
        {
            return View();
        }


        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}