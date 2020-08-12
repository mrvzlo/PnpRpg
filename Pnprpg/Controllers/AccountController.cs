using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Users;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Index(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
                return Redirect(Url.Action("Index", "Home"));
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public PartialViewResult SignIn(string returnUrl = null) =>
            PartialView("_SignIn", new LoginModel { ReturnUrl = returnUrl });

        public PartialViewResult SignUp(string returnUrl = null) =>
            PartialView("_SignUp", new RegistrationModel { ReturnUrl = returnUrl });

        [HttpPost]
        public JsonResult SignIn(LoginModel model)
        {
            var partial = this.RenderPartialViewToString("_SignIn", model);
            if (!ModelState.IsValid)
                return Json(partial);

            var response = _accountService.Login(model);
            if (response.Successful())
            {
                CreateTicket(response.Object);
                return Json(this.RenderPartialViewToString("_Redirect", GetRedirectUrl(model.ReturnUrl)));
            }

            AddModelStateErrors(response);
            partial = this.RenderPartialViewToString("_SignIn", model);
            return Json(partial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SignUp(RegistrationModel model)
        {
            var partial = this.RenderPartialViewToString("_SignUp", model);
            if (!ModelState.IsValid)
                return Json(partial);

            var response = _accountService.Register(model);
            if (response.Successful())
            {
                CreateTicket(response.Object);
                return Json(this.RenderPartialViewToString("_Redirect", GetRedirectUrl(model.ReturnUrl)));
            }

            AddModelStateErrors(response);
            partial = this.RenderPartialViewToString("_SignUp", model);
            return Json(partial);
        }

        private void CreateTicket(UserModel user)
        {
            var ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now,
                DateTime.Now.AddMonths(1), false, user.Role.ToString());
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(cookie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            return returnUrl != null && Url.IsLocalUrl(returnUrl)
                ? returnUrl // w/o http
                : Url.Action("Index", "Home");
        }
    }
}