using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Pagination;
using domatel.Models.Products;

namespace domatel.Services.Service
{
    class DomainService:IDomainService
    {
        private readonly IDomainRepository _domainRepository;
        public DomainService(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }
        public async Task<ServiceResult> AddDomain(DomainAdd model)
        {
            return await _domainRepository.AddDomain(model);
        }

        public async Task<ServiceResult> EditDomain(int id, Domain model)
        {
            return await _domainRepository.EditDomain(id,model);
        }

        public async Task<ServiceResult<Domain>> GetDomainById(int id)
        {
            return await _domainRepository.GetDomainById(id);
        }

        public async Task<ServiceResult<string>> GetAllDomain(PagingParameterModel pagingParameter)
        {
            return await _domainRepository.GetAllDomain(pagingParameter);
        }

        public async Task<ServiceResult<string>> GetDomainInfoById(int id)
        {
            return await _domainRepository.GetDomainInfoById(id);
        }

        public async Task<ServiceResult<string>> GetOwnerDomainById(int id)
        {
            return await _domainRepository.GetOwnerDomainById(id);
        }

        public async Task<ServiceResult<string>> GetAllDomainById(int id)
        {
            return await _domainRepository.GetAllDomainById(id);
        }
    }
}
