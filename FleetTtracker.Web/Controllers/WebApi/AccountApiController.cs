using FleetTracker.Data.Contract;
using FleetTracker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FleetTracker.Web.Controllers.WebApi
{
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(IUow uow)
        {
            Uow = uow;
        }

        [HttpGet]
        [Route("api/getCurrentUser")]
        public async Task<UserViewModel> GetCurrentUser()
        {
            var user = new UserViewModel();
            var appuser = await AppUserManager.FindByNameAsync(User.Identity.Name);

            user.UserId = appuser.Id;
            user.UserName = appuser.UserName;

            return user;
        }

        [HttpGet]
        [Route("api/getCurrentUserId")]
        public async System.Threading.Tasks.Task<string> GetCurrentUserId()
        {
            var user = await AppUserManager.FindByNameAsync(User.Identity.Name);
            return user.Id;
        }
    }
}