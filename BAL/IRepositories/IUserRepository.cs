using DTO.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepositories
{
    public interface IUserRepository
    {
        ResponseBO<UserBO> AddUser(UserBO UserBO);
        ResponseBO<UserBO> ModifyUser(UserBO UserBO);
        ResponseBO<UserBO> DeleteUser(UserBO UserBO);
        ResponseBO<UserBO> DeleteUser(int id);
        IEnumerable<UserBO> GetAllUser();
        ResponseBO<UserBO> GetUserById(int id);
    }
}
