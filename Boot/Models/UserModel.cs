using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using Boot.Enums;

namespace Boot.Models
{
    public class UserModel
    {
        public int Id;
        public string Username;
        public string Password;
        public string HeroName;
        public int? Room;
        public HeroModel Hero;
        public UserRole Role;

        public UserModel() { }

        public UserModel(LoginModel model, List<UserModel> users, out ServiceResponse response)
        {
            response = new ServiceResponse();
            var user = users.SingleOrDefault(x =>
                string.Equals(x.Username, model.Username, StringComparison.OrdinalIgnoreCase));
            if (user == null || !Crypto.VerifyHashedPassword(user.Password, model.Password))
            {
                response.AddError("Неверный логин или пароль");
                return;
            }

            CopyAttributes(user);
        }

        public UserModel(RegistrationModel model, List<UserModel> users, out ServiceResponse response)
        {
            response = new ServiceResponse();
            var user = users.SingleOrDefault(x => 
                string.Equals(x.Username, model.Username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                response.AddError("Логин уже занят");
                return;
            }

            Id = !users.Any() ? 0 : users.Max(x => x.Id ) + 1;
            Username = model.Username;
            Password = Crypto.HashPassword(model.Password);
            Role = UserRole.Player;
        }

        private void CopyAttributes(UserModel user)
        {
            Username = user.Username;
            Password = user.Password;
            Id = user.Id;
            HeroName = user.HeroName;
            Room = user.Room;
            Hero = user.Hero;
            Role = user.Role;
        }
    }
}