using System.Collections.Generic;
using System.Linq;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface IAccountService
    {
        IQueryable<UserEditModel> GetEditModels();
        void SaveAllUsers(List<UserEditModel> list);
        ServiceResponse<UserModel> Login(LoginModel model);
        ServiceResponse<UserModel> Register(RegistrationModel model);
    }
}
