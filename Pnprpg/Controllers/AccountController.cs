using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;

namespace Boot.Controllers
{
    public class AccountController : BaseController
    {
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

            var users = GetJsonFromFile<List<UserModel>>(FileNames.Users) ?? new List<UserModel>();
            var user = new UserModel(model, users, out var response);
            if (response.Successful())
            {
                CreateTicket(user);
                var url = model.ReturnUrl != null && Url.IsLocalUrl(model.ReturnUrl)
                    ? model.ReturnUrl
                    : Url.Action("Index", "Room");
                return Json(this.RenderPartialViewToString("_Redirect", url));
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

            var users = GetJsonFromFile<List<UserModel>>(FileNames.Users);
            var user = new UserModel(model, users, out var response);
            if (response.Successful())
            {
                users.Add(user);
                SaveJsonToFile(users, FileNames.Users);

                CreateTicket(user);
                var url = model.ReturnUrl != null && Url.IsLocalUrl(model.ReturnUrl)
                    ? model.ReturnUrl // w/o http
                    : Url.Action("Index", "Room");
                return Json(this.RenderPartialViewToString("_Redirect", url));
            }

            AddModelStateErrors(response);
            partial = this.RenderPartialViewToString("_SignUp", model);
            return Json(partial);
        }

        private void CreateTicket(UserModel user)
        {
            var ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now,
                DateTime.Now.AddMonths(1), false, user.Role.Description());
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
    }
}