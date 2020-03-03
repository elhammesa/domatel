using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Models.Core;
using domatel.Models.Criteria.SimCart;
using domatel.Models.Pagination;
using domatel.Models.Products;

namespace domatel.Interface.Interfaces.Service
{
  public  interface ISimcartService
    {
        Task<ServiceResult> AddSimcart(SimCartAdd model);
        Task<ServiceResult> EditSimcart(int id, SimCart model);
        Task<ServiceResult<SimCart>> GetSimcartById(int id);

        Task<ServiceResult<string>> GetAllSimcart(PagingParameterModel pagingParameter);
        Task<ServiceResult<string>> GetSimCartInfoById(int id);

        Task<ServiceResult<string>> GetOwnerInfoById(int id);
        Task<ServiceResult<string>> GetAllSimInfoById(int id);
    }
}
