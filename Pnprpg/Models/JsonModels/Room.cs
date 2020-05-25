using System;
using System.Collections.Generic;

namespace Boot.Models.JsonModels
{
    public class Room
    {
        public int id, players;
        public string name;
        public DateTime date;

        public List<UserModel> PlayerModels;
    }
}