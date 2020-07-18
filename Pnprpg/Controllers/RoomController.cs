using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Boot.Helpers;
using Boot.Models;
using Boot.Models.JsonModels;

namespace Boot.Controllers
{
    [Authorize]
    public class RoomController : BaseController
    {
        public ActionResult Index()
        {
            var users = GetJsonFromFile<List<UserModel>>(FileNames.Users);
            var user = users.Single(x => x.Username == User.Identity.Name);
            var rooms = GetJsonFromFile<List<Room>>(FileNames.Rooms);
            if (user.Room == null)
                return View(rooms);
            var room = rooms.SingleOrDefault(x => x.Id == user.Room);
            if (room == null)
                return View(rooms);

            room.PlayerModels = users.Where(x => x.Room == room.Id).ToList();
            return View("Room", room);
        }

        public ActionResult Join(int id)
        {
            var users = GetJsonFromFile<List<UserModel>>(FileNames.Users);
            var user = users.Single(x => x.Username == User.Identity.Name);
            if (user.Room == null)
            {
                user.Room = id;
                SaveJsonToFile(users, FileNames.Users);
            }

            return RedirectToAction("Index");
        }
    }
}