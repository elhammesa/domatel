using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Pagination;
using domatel.Models.Products;

namespace domatel.Interface.Interfaces.Service
{
   public interface IDomainService


    {
        Task<ServiceResult> AddDomain(DomainAdd model);
        Task<ServiceResult> EditDomain(int id, Domain model);
        Task<ServiceResult<Domain>> GetDomainById(int id);

        Task<ServiceResult<string>> GetAllDomain(PagingParameterModel pagingParameter);
        Task<ServiceResult<string>> GetDomainInfoById(int id);
        Task<ServiceResult<string>> GetOwnerDomainById(int id);
        Task<ServiceResult<string>> GetAllDomainById(int id);
       
    }
}
