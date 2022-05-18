using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainAppWebApi.Models;
using TrainAppWebApi.Models.ViewModels;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;
        public AuthController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }


        //--------------Testing only 
        [AllowAnonymous]
        [HttpGet("user")]
        public IActionResult GetUser([FromBody] UserLogin userLogin)
        {
            return Ok(Authenticate(userLogin));
        }

        //--------------------------

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var userData = Authenticate(userLogin);

            if(userData != null)
            {
                var tokenData = Generate(userData);
                return Ok(new UserTokenViewModel()
                {
                    user = userData,
                    token = tokenData
                });
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] UserSignupViewModel userSignupViewModel)
        {

            if (_userService.IsUsernameAvailable(userSignupViewModel.Username))
            {
                var user = _userService.AddUser(userSignupViewModel);

                var userLogin = new UserLogin
                {
                    Username = user.Username,
                    Password = user.Password
                };

                if (user != null)
                {
                    var login = _userService.AddUserLogin(userLogin);

                    if(login != null)
                        return Ok(user); //success
                    else
                        return BadRequest("Failed");
                }
                else
                    return BadRequest("Failed");
            }
            else
                return BadRequest("Username is taken");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Email,user.EmailAddress),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(14),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin userLogin)
        {
            return _userService.GetUser(userLogin);
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    UserId = Guid.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value),
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
