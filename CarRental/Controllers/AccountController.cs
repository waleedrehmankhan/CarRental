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
using Newtonsoft.Json;

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
        [ValidateFilter]
        public async Task<Object> OnRegisterAsync(RegisterUserDto Input) 
        {
            ReturnMessage returnmessage = new ReturnMessage(1, "User Created Successfully ");
            try
            {
                var existinguser = await _userManager.FindByNameAsync(Input.Email);

                if (existinguser != null)
                {
                    returnmessage.msg = "User Already Exist";
                    returnmessage.msgCode = -3;
                }
                else
                {
                    var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName };
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var roleCheck = await _roleManager.RoleExistsAsync(Input.UserRole);
                        if (!roleCheck)
                        {
                            returnmessage.msg = "Role Doesnot Exist";
                            returnmessage.msgCode = -3;
                        }

                        await _userManager.AddToRoleAsync(user, Input.UserRole);

                    }
                }

                return this.Content(returnmessage.returnMessage(null),
                       "application/json");

            }
            catch (Exception ex)
            {
                returnmessage.msg = ex.Message.ToString();
                returnmessage.msgCode = -3;
                return this.Content(returnmessage.returnMessage(null));
            }

       

        }

        [HttpPost]
        [Route("Login")]
        [ValidateFilter]
        public async Task<Object> OnLoginAsync(LoginUserDto Input)
        {
            try
            {


                ReturnMessage rm = new ReturnMessage(1, "Login Succesful");
                List<RegisterUserDto> registeruserlist = new List<RegisterUserDto>();
                var user = await _userManager.FindByNameAsync(Input.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    var token = GenerateSecurityToken(user);
                    var usertoreturn = _mapper.Map<RegisterUserDto>(user);
                    usertoreturn.CurrentToken = token;
                    var role= await _userManager.GetRolesAsync(user);
                    usertoreturn.UserRole = role[0];
                    registeruserlist.Add(usertoreturn);
                }
                else
                {
                    rm.msgCode = -1;
                    rm.msg = "Login Failed";
                }
                return this.Content(rm.returnMessage(new PagedResultDto<RegisterUserDto>
                       (registeruserlist.AsQueryable(), 0, 0)),
                       "application/json");
            }
            catch (Exception ex)
            {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = -3,
                    msg = ex.Message
                }), "application/json");
            }

           
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