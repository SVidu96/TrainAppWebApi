using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainAppWebApi.Models.ViewModels;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : Controller
    {
        public readonly IWebHostEnvironment _env;
        public UserRef UserRef;
        public BaseApiController(IWebHostEnvironment environment)
        {
            _env = environment;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = identity.Claims;

            var UserId = Guid.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value);
            var Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
            var EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
            var FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value;
            var LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value;
            var Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value;

            UserRef = new UserRef
            {
                UserId = UserId,
                Username = Username,
                EmailAddress = EmailAddress,
                FirstName = FirstName,
                LastName = LastName,
                Role = Role
            };
        }
    }
}
