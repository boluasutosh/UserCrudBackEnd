using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.BusinessObject;

namespace DAL.ContextClass.Users
{
    static class DataToObject
    {
        //Chage the sql data object to business object
        //We are doint this to maintain the architecture and get the information on control level
        //we can get information like what element added, what is modified, what go deleted etc 
        //Controller can understand Business object so we are converting the Sql data object to business object

        private enum enumUserRole
        {
            Admin = 1,
            CustomerExecutive = 2
        }
        internal static UserBO ToUserDTO(this User user)
        {
            UserBO userBO = new UserBO()
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Number = user.Number,
                Role = getUserRole(user.UserID)
            };
            return userBO;
        }

        private static string getUserRole(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return enumUserRole.Admin.ToString();
                case 2:
                    return enumUserRole.CustomerExecutive.ToString();
                default:
                    return enumUserRole.CustomerExecutive.ToString();
            }
        }

    }
}
