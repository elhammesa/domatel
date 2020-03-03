using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Models.Core;
using domatel.Models.Criteria.Phone;
using domatel.Models.Pagination;
using domatel.Models.Products;

namespace domatel.Interface.Interfaces.Repository
{
   public interface IPhoneRepository
    {
        Task<ServiceResult> AddPhone(PhoneAdd model);
        Task<ServiceResult> EditPhone(int id, Phone model);
        Task<ServiceResult<Phone>> GetPhoneById(int id);

        Task<ServiceResult<string>> GetAllPhone(PagingParameterModel pagingParameter);
        Task<ServiceResult<string>> GetPhoneInfoById(int id);
        Task<ServiceResult<string>> GetOwnerPhoneById(int id);
        Task<ServiceResult<string>> GetAllPhoneById(int id);




    }
}
