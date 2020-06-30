using Boot.Enums;
using Boot.Helpers;
using Boot.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Boot.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public ActionResult Users()
        {
            var users = GetJsonFromFile<List<UserModel>>(FileNames.Users); 
            return View(GetEditModels(users));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Users(List<UserEditModel> list)
        {
            var currentUsers = GetJsonFromFile<List<UserModel>>(FileNames.Users);
            
            foreach(var user in list)
            {
                var changed = currentUsers.Single(x => x.Id == user.Id);
                changed.Role = user.Role;
            }
            SaveJsonToFile(currentUsers, FileNames.Users);
            return View(GetEditModels(currentUsers));
        }

        private List<UserEditModel> GetEditModels(List<UserModel> list)
            => list.Select(x => new UserEditModel { Id = x.Id, Role = x.Role, Username = x.Username }).ToList();
    }
}