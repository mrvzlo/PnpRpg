using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Models;
using Boot.Models.JsonModels;

namespace Boot.Controllers
{
    [Authorize]
    public class RoomController : BaseController
    {
        public ActionResult Index()
        {
            var users = GetJsonFromFile<List<UserModel>>(FileType.Users);
            var user = users.Single(x => x.Username == User.Identity.Name);
            var rooms = GetJsonFromFile<List<Room>>(FileType.Rooms);
            if (user.Room == null)
                return View(rooms);
            var room = rooms.SingleOrDefault(x => x.id == user.Room);
            if (room == null)
                return View(rooms);

            room.PlayerModels = users.Where(x => x.Room == room.id).ToList();
            return View("Room", room);
        }

        public ActionResult Join(int id)
        {
            var users = GetJsonFromFile<List<UserModel>>(FileType.Users);
            var user = users.Single(x => x.Username == User.Identity.Name);
            if (user.Room == null)
            {
                user.Room = id;
                SaveJsonToFile(users, FileType.Users);
            }

            return RedirectToAction("Index");
        }
    }
}