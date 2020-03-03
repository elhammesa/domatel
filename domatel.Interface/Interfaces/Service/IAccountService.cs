using System.Threading.Tasks;
using domatel.Models;
using domatel.Models.Account;
using domatel.Models.Core;

namespace domatel.Interface
{
    public interface IAccountService
    {
        Task<ServiceResult> RegisterUser(RegisterViewModel model);
        Task<ServiceResult> ResetPassword(ResetPassword model);
    }
}