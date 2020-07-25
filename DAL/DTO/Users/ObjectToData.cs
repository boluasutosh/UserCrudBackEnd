using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.BusinessObject;

namespace DAL.ContextClass.Users
{
    internal enum enumUserRole
    {
        Admin = 1,
        CustomerExecutive = 2
    }
    static class ObjectToData
    {

        //Chage the business object to sql data object
        //We are doint this to maintain the architecture
        internal static User ToUserOTB(this UserBO userBO)
        {
            User user = new User()
            {
                UserID = userBO.UserID,
                Name = userBO.Name,
                Email = userBO.Email,
                Number = userBO.Number,
                RoleId = getUserRoleId(userBO.Role)
            };

            
            return user;
        }

        private static int getUserRoleId(string role)
        {
            switch (role)
            {
                case "Admin":
                    return (int)enumUserRole.Admin;
                case "CustomerExecutive":
                    return (int)enumUserRole.CustomerExecutive;
                default:
                    return (int)enumUserRole.CustomerExecutive;
            }
        }
    }
}
