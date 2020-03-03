using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
using domatel.Models.Criteria.SimCart;
using domatel.Models.Pagination;
using domatel.Models.Products;

namespace domatel.Services.Service
{
    class SimcartService:ISimcartService
    {
        private readonly ISimcartRepository _simcartRepository;

        public SimcartService(ISimcartRepository simcartRepository)
        {
            _simcartRepository = simcartRepository;
        }
        public async Task<ServiceResult> AddSimcart(SimCartAdd model)
        {
           return await _simcartRepository.AddSimcart(model);
        }

        public async Task<ServiceResult> EditSimcart(int id, SimCart model)
        {
            return await _simcartRepository.EditSimcart( id,model);
        }

        public async Task<ServiceResult<SimCart>> GetSimcartById(int id)
        {
            return await _simcartRepository.GetSimcartById(id);
        }

        public async Task<ServiceResult<string>> GetAllSimcart(PagingParameterModel pagingParameter)
        {
            return await _simcartRepository.GetAllSimcart(pagingParameter);
        }

        public async Task<ServiceResult<string>> GetSimCartInfoById(int id)
        {
            return await _simcartRepository.GetSimCartInfoById(id);
        }

        public  async Task<ServiceResult<string>> GetOwnerInfoById(int id)
        {
            return await _simcartRepository.GetOwnerInfoById(id);
        }

        public async Task<ServiceResult<string>> GetAllSimInfoById(int id)
        {
            return await _simcartRepository.GetAllSimInfoById(id);
        }
    }
}
