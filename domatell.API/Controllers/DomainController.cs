using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Criteria.SimCart;
using domatel.Models.Pagination;
using domatel.Models.Products;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace domatell.API.Controllers
{
    [Route("api/[controller]")]
 
    [ApiController]
   
    public class DomainController : ControllerBase
    {
        private readonly IDomainService _domainService;

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        [HttpGet("GetAllDomain")]
        public async Task<ServiceResult<string>> GetAllDomain([FromQuery]PagingParameterModel pagingParameter)
        {
            return await _domainService.GetAllDomain(pagingParameter);
        }

        [HttpPost]
        [Route("PostDomain")]
        public async Task<ServiceResult> PostDomain( DomainAdd model)
        {
            return await _domainService.AddDomain(model);
        }

        [HttpGet("GetDomainInfoById/{id}")]
        public async Task<ServiceResult<string>> GetDomainInfoById(int id)
        {
            return await _domainService.GetDomainInfoById(id);
        }

        [HttpGet("GetOwnerDomainById/{id}")]
        public async Task<ServiceResult<string>> GetOwnerDomainById(int id)
        {
            return await _domainService.GetOwnerDomainById(id);
        }

        [HttpGet("GetAllDomainById(Id)/{id}")]
        public async Task<ServiceResult<string>> GetAllDomainById(int id)
        {
            return await _domainService.GetAllDomainById(id);
        }

    }
}