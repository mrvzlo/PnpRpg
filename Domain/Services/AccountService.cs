using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models.Processing;
using Pnprpg.DomainService.Models.Users;

namespace Pnprpg.Domain.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryable<UserEditModel> GetEditModels()
        {
            return _userRepository.Select().ProjectTo<UserEditModel>(MapperConfig);
        }

        public void SaveAllUsers(List<UserEditModel> list)
        {
            var users = _userRepository.Select();
            foreach (var user in users) 
                user.Role = list.Single(x => x.Id == user.Id).Role;
            _userRepository.BatchInsert(users);
        }

        public ServiceResponse<UserModel> Login(LoginModel model)
        {
            var response = new ServiceResponse<UserModel>();
            var users = _userRepository.Select();
            var user = users.SingleOrDefault(x => x.Username.ToUpper() == model.Username.ToUpper());
            if (user == null || !Crypto.VerifyHashedPassword(user.Password, model.Password))
            {
                response.AddError("Неверный логин или пароль");
                return response;
            }

            response.Object = Mapper.Map<UserModel>(user);
            return response;
        }

        public ServiceResponse<UserModel> Register(RegistrationModel model)
        {
            var response = new ServiceResponse<UserModel>();
            var users = _userRepository.Select();
            var user = users.SingleOrDefault(x => x.Username.ToUpper() == model.Username.ToUpper());
            if (user != null)
            {
                response.AddError("Логин уже занят");
                return response;
            }
            
            user = new AppUser
            {
                Username = model.Username,
                Password = Crypto.HashPassword(model.Password),
                Role = UserRole.Player
            };
            
            _userRepository.InsertOrUpdate(user);
            response.Object = Mapper.Map<UserModel>(user);
            return response;
        }
    }
}
