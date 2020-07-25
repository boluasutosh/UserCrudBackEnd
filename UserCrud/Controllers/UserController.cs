using BAL.IRepositories;
using BAL.Repositories;
using DTO.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace UserCrud.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository UserRepository;

        public UserController()
        {
            UserRepository = new UserRepository();
        }
        public IHttpActionResult GetAllUser()
        {
            IEnumerable<UserBO> users = UserRepository.GetAllUser();
            if(users != null)
            {
                return Ok<IEnumerable<UserBO>>(users);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Nothing Found");
            }
            
        }

        public IHttpActionResult GetUserById([FromUri]int id)
        {
            ResponseBO<UserBO> response = UserRepository.GetUserById(id);
            if (response.IsSuccess)
            {
                return Ok<UserBO>(response.ReturnedObject);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Unable to add User");
            }

        }

        public IHttpActionResult AddUser([FromBody]UserBO UserBO)
        {
            ResponseBO<UserBO> response = UserRepository.AddUser(UserBO);
            if (response.IsSuccess)
            {
                return Ok<UserBO>(response.ReturnedObject);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Unable to add User");
            }
        }

        [HttpPut]
        public IHttpActionResult ModifyUser([FromBody]UserBO UserBO)
        {
            ResponseBO<UserBO> response = UserRepository.ModifyUser(UserBO);
            if (response.IsSuccess)
            {
                return Ok<UserBO>(response.ReturnedObject);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Unable to Modify User");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser([FromBody]UserBO UserBO)
        {
            ResponseBO<UserBO> response = UserRepository.DeleteUser(UserBO);
            if (response.IsSuccess)
            {
                return Ok<UserBO>(response.ReturnedObject);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Unable to Delete User");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            ResponseBO<UserBO> response = UserRepository.DeleteUser(id);
            if (response.IsSuccess)
            {
                return Ok<UserBO>(response.ReturnedObject);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Unable to Delete User");
            }

        }



    }
}
