using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
using domatel.Models.Criteria.Phone;
using domatel.Models.Pagination;
using domatel.Models.Products;

namespace domatel.Services.Service
{
   public class PhoneService:IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        public async Task<ServiceResult> AddPhone(PhoneAdd model)
        {
            return await _phoneRepository.AddPhone(model);
        }

        public Task<ServiceResult> EditPhone(int id, Phone model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<Phone>> GetPhoneById(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<ServiceResult<string>> GetAllPhone(PagingParameterModel pagingParameter)
        {
            return await _phoneRepository.GetAllPhone(pagingParameter);
        }

        public async Task<ServiceResult<string>> GetPhoneInfoById(int id)
        {
            return await _phoneRepository.GetPhoneInfoById(id);
        }

        public async Task<ServiceResult<string>> GetOwnerPhoneById(int id)
        {
            return await _phoneRepository.GetOwnerPhoneById(id);
        }

        public async Task<ServiceResult<string>> GetAllPhoneById(int id)
        {
            return await _phoneRepository.GetAllPhoneById(id);
        }
    }
}
