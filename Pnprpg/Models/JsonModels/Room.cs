using System;
using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Room
    {
        public int Id, Players;
        public string Name;
        public DateTime Date;

        public List<UserModel> PlayerModels;
    }
}