using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            _userRepository = userRepository;
        }

        public IQueryable<UserEditModel> GetEditModels()
        {
            return _userRepository.Select().ProjectTo<UserEditModel>(MapperConfig);
        }

        public void SaveAllUsers(List<UserEditModel> list)
        {
            var users = _userRepository.Select().ToList();
            foreach (var user in users) 
                user.Role = list.Single(x => x.Id == user.Id).Role;
            _userRepository.BatchInsert(users.AsQueryable());
        }

        public ServiceResponse<UserModel> Login(LoginModel model)
        {
            var response = new ServiceResponse<UserModel>();
            var users = _userRepository.Select();
            var user = users.SingleOrDefault(x => x.Username.ToUpper() == model.Username.ToUpper());
            if (user == null || !Crypto.VerifyHashedPassword(user.Password, model.Password))
                return response.AddError("Неверный логин или пароль");

            response.Object = Mapper.Map<UserModel>(user);
            return response;
        }

        public ServiceResponse<UserModel> Register(RegistrationModel model)
        {
            var response = new ServiceResponse<UserModel>();
            var users = _userRepository.Select();
            var user = users.SingleOrDefault(x => x.Username.ToUpper() == model.Username.ToUpper());
            if (user != null)
                return response.AddError("Логин уже занят");

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
