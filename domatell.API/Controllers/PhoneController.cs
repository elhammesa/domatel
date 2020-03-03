using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;

using domatel.Models.Criteria.Phone;
using domatel.Models.Pagination;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace domatell.API.Controllers
{
    [Route("api/[controller]")]
  
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet("GetAllPhone")]
        public async Task<ServiceResult<string>> GetAllPhone([FromQuery]PagingParameterModel pagingParameter)
        {
            return await _phoneService.GetAllPhone(pagingParameter);
        }

        [HttpGet("GetPhoneInfoById")]
        public async Task<ServiceResult<string>> GetPhoneInfoById(int id)
        {
            return await _phoneService.GetPhoneInfoById(id);
        }

        [HttpGet("GetOwnerPhoneById")]
        public async Task<ServiceResult<string>> GetOwnerPhoneById(int id)
        {
            return await _phoneService.GetOwnerPhoneById(id);
        }

        [HttpGet("GetAllPhoneById")]
        public async Task<ServiceResult<string>> GetAllPhoneById(int id)
        {
            return await _phoneService.GetAllPhoneById(id);
        }

        [HttpPost]
        [Route("PostPhone")]
        public async Task<ServiceResult> PostPhone(PhoneAdd model)
        {
            return await _phoneService.AddPhone(model);
        }
    }
}