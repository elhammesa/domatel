using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Criteria.User;

using domatel.Models.Users;

namespace domatel.Interface.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<ServiceResult> AddUser(User model);

        Task<ServiceResult> EditUser(User model);
        Task<ServiceResult<string>> GetUserById(string userId);
     
        Task<ServiceResult<string>> GetAllUser();
        Task<ServiceResult<string>> Domain(string userId);
        Task<ServiceResult<string>> SimCart(string userId);

        Task<ServiceResult<string>> Phone(string userId);

        Task<ServiceResult<string>> BidSimCart(string userId);
        Task<ServiceResult<string>> BidDomain(string userId);
        Task<ServiceResult<string>> BidPhone(string userId);

    }
}
