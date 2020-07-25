using DTO.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ContextInterface.Users
{
    public interface IUser
    {
        ResponseBO<UserBO> AddUser(UserBO userBO);
        ResponseBO<UserBO> ModifyUser(UserBO userBO);
        ResponseBO<UserBO> DeleteUser(UserBO userBO);
        ResponseBO<UserBO> DeleteUser(int id);
        IEnumerable<UserBO> GetAllUser();
        ResponseBO<UserBO> GetUserById(int id);
    }
}
