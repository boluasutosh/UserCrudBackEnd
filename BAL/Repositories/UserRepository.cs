using BAL.IRepositories;
using DAL.ContextClass.Users;
using DAL.ContextInterface.Users;
using DTO.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        IUser UserContext;
        public UserRepository()
        {
            UserContext = new UserContext();
        }
        public UserRepository(IUser contextObject)
        {
            UserContext = contextObject;
        }
        public ResponseBO<UserBO> AddUser(UserBO UserBO)
        {
            return UserContext.AddUser(UserBO);
        }

        public ResponseBO<UserBO> DeleteUser(UserBO UserBO)
        {
            return UserContext.DeleteUser(UserBO);
        }

        public ResponseBO<UserBO> DeleteUser(int id)
        {
            return UserContext.DeleteUser(id);
        }

        public IEnumerable<UserBO> GetAllUser()
        {
            return UserContext.GetAllUser();
        }

        public ResponseBO<UserBO> GetUserById(int id)
        {
            return UserContext.GetUserById(id);
        }

        public ResponseBO<UserBO> ModifyUser(UserBO UserBO)
        {
            return UserContext.ModifyUser(UserBO);
        }

    }
}
