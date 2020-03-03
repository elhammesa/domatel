using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.Interface;
using domatel.Models;
using domatel.Models.Account;
using domatel.Models.Core;

using domatel.Models.Users;
using Microsoft.AspNetCore.Identity;

using domatel.Services.Utility;

namespace domatel.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        public AccountService(UserManager<User> userManager, IUserService userService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _userService = userService;
            _signInManager = signInManager;
        }

        public async Task<ServiceResult> RegisterUser(RegisterViewModel model)
        {
            try
            {
                var user = new User { UserName = model.Email, Email = model.Email, PhoneNumber = model.Mobile };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return new ServiceResult
                    {
                        Message = string.Join(",", result.Errors.Select(q => q.Description)),
                        Status = (int)Configuration.ServiceResultStatus.Error
                    };

                await _userService.AddUser(new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Mobile = model.Mobile,
                    Phone = string.Empty

                });

              
                //await _userService.AddRoleToUser(user.Id, new PairData<string, string>
                //{
                //    Key = Configuration.StudentRoleId,
                //    Value = "Student"
                //});

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new ServiceResult
                {
                   
                    Status = (int)Configuration.ServiceResultStatus.Success

                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error

                };
            }
        }

        public async Task<ServiceResult> LoginUser(LoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return new ServiceResult
                    {
                        Message = "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.",
                        Status = (int)Configuration.ServiceResultStatus.Error

                    };
               
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: true);

                if (!result.Succeeded)
                    return new ServiceResult
                    {
                        Message = string.Join(",", "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند."),
                        Status = (int)Configuration.ServiceResultStatus.Error
                    };
                return new ServiceResult
                {

                    Status = (int)Configuration.ServiceResultStatus.Success

                };


            }
            catch (Exception e)
            {
                return new ServiceResult
                {

                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error

                };
            }
        }

        public async Task<ServiceResult> ResetPassword(ResetPassword model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                    return new ServiceResult
                    {
                        Message = "User Not Found",
                        Status = (int)Configuration.ServiceResultStatus.Error

                    };
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, code, model.Password);

                if (!result.Succeeded)
                    return new ServiceResult
                    {
                        Message = string.Join(",", result.Errors.Select(q => q.Description)),
                        Status = (int)Configuration.ServiceResultStatus.Error
                    };

                return new ServiceResult
                {
                    Message = "Password Changed!",
                    Status = (int)Configuration.ServiceResultStatus.Success

                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }


    }
}
