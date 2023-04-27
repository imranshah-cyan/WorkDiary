using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceDotNet.Api.Classes;
using ServiceDotNet.Api.Models;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("validate")]

        [System.Web.Http.HttpGet]
        public UserValidateLogin_sp_Result Validate(string userName, string password)
        {
            var objUser = new USER { USER_NAME = userName, PASSWORD = new Crypto().Encrypt(password) };
            var userService = new UserRepository();
            var objUserInfo = userService.ValidateUser(objUser);
            return objUserInfo;
        }

        [Route("all")]
        [System.Web.Http.HttpGet]
        public List<UserGetAll_sp_Result> GetUsers()
        {
            return new UserRepository().GetUserList(-1,-1,-1,-1,-1,null,null);
        }

        // Insert New User
        [Route("insert")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody]User user)
        {
            //First check the user exists or not
            if (new UserService().UserExists(user.USER_NAME))
                return Json(new {message = "User already Exists"});

            //Insert User
            int? newUser = new UserService().InsertUser(user);
            if (newUser.HasValue)
            {
                //Activate User
                new UserService().UserActivate(user);
                return Json(user);
                //return null;
            }
            else
                return Json(new { message = "Failed to Insert User" }); ;
        }

        // Change Password
        [Route("updatePassword")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdatePass([FromBody]User user)
        {
            //First check the user exists or not
            if (new UserService().UserExists(user.USER_NAME))
            {
                int? res = new UserService().UserChangePassword(user);
                if(res.HasValue)
                {
                    return Json(res);
                }
                return Json(new { message = "Failed to Update User Password" });
            }

            return Json(new { message = "User not exists" }); ;
        }




    }
}