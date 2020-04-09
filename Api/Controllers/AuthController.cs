using Core;
using Core.Model;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        private readonly UserManager<ApiUser> _userManager = null;
        private readonly SignInManager<ApiUser> _signInManager = null;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration,
            SignInManager<ApiUser> signInManager,
            UserManager<ApiUser> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromForm]LoginModel login)
        {
            IActionResult result = Unauthorized();
            ApiUser apiUser = await _userManager.FindByNameAsync(login.Username);
            if (apiUser != null)
            {
                SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(apiUser, login.Password, false);
                if (signInResult.Succeeded)
                {
                    return Ok(BuildJwtToken(apiUser.Id));
                }
            }
            return result;
        }
#if DEBUG
        [AllowAnonymous]
        public async Task<ApiResponseModel> CreateDefaultUser()
        {
            IdentityResult identityResult = await _userManager.CreateAsync(new ApiUser() { UserName = "admin", Email = "s@scorz.org" }, "admin");
            string result;
            if (identityResult.Succeeded)
            {
                result = "Default User Created, Eureka!";
            }
            else
            {
                result = $"Error! Code: { identityResult.Errors.FirstOrDefault().Code }, Description: {identityResult.Errors.FirstOrDefault().Description }";
            }

            return new ApiResponseModel()
            {
                Data = result
            };
        }
#endif
        private async Task<string> BuildJwtToken(string userId = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = CurrentUser;
            }

            JwtSecurityToken token = await Task.Run(() =>
            {
                List<Claim> claims = new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Sub, userId)
            };
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                return new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: creds);
            });
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}