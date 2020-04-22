using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public AuthController(UserManager<ApplicationUser> userManager,IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<ContentResult> Post(RegistrationDto registrationDto)
        {


            try
            {
                ReturnMessage returnmessage = new ReturnMessage(-4, "Login Failed");
                List<RegistrationDto> userlist = new List<RegistrationDto>();
                var userToVerify = await _userManager.FindByNameAsync(registrationDto.UserName);

                if (userToVerify != null)
                {
                    // check the credentials  
                    
                    if (await _userManager.CheckPasswordAsync(userToVerify, registrationDto.Password))
                    {
                        returnmessage.msgCode = 1;
                        returnmessage.msg = "Login Succeful";
                        var userstoreturn = _mapper.Map<RegistrationDto>(userToVerify);
                        userstoreturn.CurrentToken = GetRandomToken(userstoreturn.UserName);
                        userlist.Add(userstoreturn);
                    }
                }
                return this.Content(returnmessage.returnMessage(new PagedResultDto<RegistrationDto>
                       (userlist.AsQueryable(), 1,1)),
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


        public string GetRandomToken(string userName)
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken(userName);
            return token;
        }
    }
}