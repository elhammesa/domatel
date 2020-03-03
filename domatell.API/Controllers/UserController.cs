using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.Interface;
using domatel.Models.Account;
using domatel.Models.Core;
using domatel.Models.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace domatell.API.Controllers
{
    [Route("api/[controller]")]
    
 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UserController(IUserService userService,IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }
       

        [HttpPut("PutUser")]
        public async Task<ServiceResult> PutUser(User model)
        {
            return await _userService.EditUser(model);
        }

        [HttpGet("GetAllUser")]
        public async Task<ServiceResult<string>> GetAllUser()
        {
            return await _userService.GetAllUser();
        }

        [HttpPost]
        [Route("PostUser")]
        public async Task<ServiceResult> PostUser(RegisterViewModel model)
        {
            return await _accountService.RegisterUser(model);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ServiceResult<string>> GetUserById(string userId)
        {
            return await _userService.GetUserById(userId);
        }

        [HttpGet("GetDomain/{id}")]
        public async Task<ServiceResult<string>> GetDomain(string userId)
        {
            return await _userService.Domain(userId);
        }

        [HttpGet("GetMySimCart/{id}")]
        public async Task<ServiceResult<string>> GetSimCart(string userId)
        {
            return await _userService.SimCart(userId);
        }

        [HttpGet("GetMyPhone/{id}")]
        public async Task<ServiceResult<string>> GetPhone(string userId)
        {
            return await _userService.Phone(userId);
        }

        [HttpGet("GetBidSimCart/{id}")]
        public async Task<ServiceResult<string>> GetBidSimCart(string userId)
        {
            return await _userService.BidSimCart(userId);
        }

        [HttpGet("GetBidDomain/{id}")]
        public async Task<ServiceResult<string>> GetBidDomain(string userId)
        {
            return await _userService.BidDomain(userId);
        }

        [HttpGet("GetBidPhone/{id}")]
        public async Task<ServiceResult<string>> GetBidPhone(string userId)
        {
            return await _userService.BidPhone(userId);
        }
    }
}