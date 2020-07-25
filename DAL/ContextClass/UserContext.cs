using DAL.ContextInterface.Users;
using DTO.BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ContextClass.Users
{
    public class UserContext : IUser
    {
        private dbUserEntities _context;
        public UserContext()
        {
            _context = new dbUserEntities();
        }
        public ResponseBO<UserBO> AddUser(UserBO UserBO)
        {
            ResponseBO<UserBO> responseBO = new ResponseBO<UserBO>();
            try
            {
                User User = _context.Users.Add(UserBO.ToUserOTB());
                _context.SaveChanges();
                responseBO.ReturnedObject = User.ToUserDTO();
                responseBO.IsSuccess = true;
                responseBO.ResponseMessage = "Successfully Inserted User";

                return responseBO;
            }
            catch (Exception e)
            {
                responseBO.IsSuccess = false;
                responseBO.ResponseMessage = e.InnerException.ToString();
                return responseBO;
            }

        }

        public ResponseBO<UserBO> DeleteUser(UserBO UserBO)
        {
            ResponseBO<UserBO> responseBO = new ResponseBO<UserBO>();
            try
            {
                User User = _context.Users.Remove(FindElementByID(UserBO.UserID));
                _context.SaveChanges();
                responseBO.ReturnedObject = User.ToUserDTO();
                responseBO.IsSuccess = true;
                responseBO.ResponseMessage = "Successfully deleted the User";
                return responseBO;
            }
            catch (Exception e)
            {
                responseBO.IsSuccess = false;
                responseBO.ResponseMessage = e.InnerException.ToString();
                return responseBO;
            }
        }

        public ResponseBO<UserBO> DeleteUser(int id)
        {
            ResponseBO<UserBO> responseBO = new ResponseBO<UserBO>();
            try
            {
                User User = _context.Users.Remove(FindElementByID(id));
                _context.SaveChanges();
                responseBO.ReturnedObject = User.ToUserDTO();
                responseBO.IsSuccess = true;
                responseBO.ResponseMessage = "Successfully deleted the User";
                return responseBO;
            }
            catch (Exception e)
            {
                responseBO.IsSuccess = false;
                responseBO.ResponseMessage = e.InnerException.ToString();
                return responseBO;
            }
        }

        public IEnumerable<UserBO> GetAllUser()
        {
            return _context.Users.ToList().Select(User => User.ToUserDTO());
        }

        public ResponseBO<UserBO> GetUserById(int id)
        {
            ResponseBO<UserBO> responseBO = new ResponseBO<UserBO>();
            try
            {
                responseBO.ReturnedObject = FindElementByID(id).ToUserDTO();
                responseBO.IsSuccess = true;
                responseBO.ResponseMessage = "Successfully got the User";
                return responseBO;
            }
            catch (Exception e)
            {
                responseBO.IsSuccess = false;
                responseBO.ResponseMessage = e.InnerException.ToString();
                return responseBO;
            }
        }

        public ResponseBO<UserBO> ModifyUser(UserBO UserBO)
        {
            ResponseBO<UserBO> responseBO = new ResponseBO<UserBO>();
            try
            {
                _context.Entry(UserBO.ToUserOTB()).State = EntityState.Modified;
                _context.SaveChanges();
                responseBO.ReturnedObject = FindElementByID(UserBO.UserID).ToUserDTO();
                responseBO.IsSuccess = true;
                responseBO.ResponseMessage = "Successfully Modified the User";
                return responseBO;
            }
            catch (Exception e)
            {
                responseBO.IsSuccess = false;
                responseBO.ResponseMessage = e.InnerException.ToString();
                return responseBO;
            }
        }

        private User FindElementByID(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
