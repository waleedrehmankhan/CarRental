using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<ApplicationUser> signInManager, 
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _config = config;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> OnRegisterAsync(RegisterUserDto Input) 
        {
            
            var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName };
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded) {
                _logger.LogInformation("User created a new account with password.");

                var roleCheck = await _roleManager.RoleExistsAsync(Input.UserRole);
                if (!roleCheck)
                    return BadRequest(new { message = "Something went wrong!" } );
                
                await _userManager.AddToRoleAsync(user, Input.UserRole);
            }
                

            return Ok(result);

        }

        [HttpPost]
        [Route("Login")]
        public async Task<Object> OnLoginAsync(LoginUserDto Input)
        {
            
            var user = await _userManager.FindByNameAsync(Input.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user,Input.Password)){
                var token = GenerateSecurityToken(user);
                return Ok(new { token });
            }
            
            return BadRequest(new { message = "username or password is incorrect!" }); 
        }

        [HttpPost]
        [Route("Roles")]
        public ContentResult GetRoles()
        {
            //TODO:
            // have to do pagination thing, otherwise angular component wasn't working.
            ReturnMessage rm = new ReturnMessage(1, "Success");
            var identityRoles = _roleManager.Roles.ToList();
            var userRolesToReturn = 
                _mapper.Map<IEnumerable<IdentityRoleDto>>(identityRoles);

            return this.Content(rm.returnMessage(new PagedResultDto<IdentityRoleDto>
                    (userRolesToReturn.AsQueryable(), 1, 10)),
                    "application/json");
        }

        // Test Method
        // TOKEN test Action
        [HttpGet]
        [Route("Profile")]
        [Authorize]
        public async Task<Object> UserProfile()
        {
            
            string userId = User.Claims.First( u => u.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            return new 
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email
            };
        }

        public string GenerateSecurityToken(ApplicationUser _user)
        {
            //TODO: Proper Implementation of Key from Config.
            var key = Encoding.UTF8.GetBytes("PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("UserID", _user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

    }
}