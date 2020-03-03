using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface;
using domatel.Interface.Interfaces.Repository;
using domatel.Models;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Criteria.User;
using domatel.Models.Users;


namespace domatel.Services.Service
{
    class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ServiceResult> AddUser(User model)
        {
            return await _userRepository.AddUser(model);
        }



        public async Task<ServiceResult> EditUser( User model)
        {
            return await _userRepository.EditUser(model);
        }

        public async Task<ServiceResult<string>> GetUserById(string userId)
        {
            return await _userRepository.GetUserById(userId);
        }

       

        public async Task<ServiceResult<string>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }

        public async Task<ServiceResult<string>> Domain(string userId)
        {
            return await _userRepository.Domain(userId);
        }

        public async Task<ServiceResult<string>> SimCart(string userId)
        {
            return await _userRepository.SimCart(userId);
        }

        public async Task<ServiceResult<string>> Phone(string userId)
        {
            return await _userRepository.Phone(userId);
        }

        public  async Task<ServiceResult<string>> BidSimCart(string userId)
        {
            return await _userRepository.BidSimCart(userId);
        }

        public async Task<ServiceResult<string>> BidDomain(string userId)
        {
            return await _userRepository.BidDomain(userId);
        }

        public async Task<ServiceResult<string>> BidPhone(string userId)
        {
            return await _userRepository.BidPhone(userId);
        }
    }
}
