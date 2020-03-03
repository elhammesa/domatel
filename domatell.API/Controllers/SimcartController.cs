using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
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
    public class SimcartController : ControllerBase
    {
        private readonly ISimcartService _simcartService;

        public SimcartController(ISimcartService simcartService)
        {
            _simcartService = simcartService;
        }

        [HttpGet("GetSimCartInfoById/{id}")]
        public async Task<ServiceResult<string>> GetSimCartInfoById(int id)
        {
            return await _simcartService.GetSimCartInfoById(id);
        }

        [HttpGet("GetAllSimcart")]
        public async Task<ServiceResult<string>> GetAllSimcart([FromQuery]PagingParameterModel pagingParameter)
        {
            return await _simcartService.GetAllSimcart(pagingParameter);
        }

        [HttpGet("GetOwnerInfoById/{id}")]
        public async Task<ServiceResult<string>> GetOwnerInfoById(int id)
        {
            return await _simcartService.GetOwnerInfoById(id);
        }

        [HttpGet("GetAllSimInfoById/{id}")]
        public async Task<ServiceResult<string>> GetAllSimInfoById(int id)
        {
            return await _simcartService.GetAllSimInfoById(id);
        }

      

        [HttpPost]
        [Route("PostSimCart")]
        public async Task<ServiceResult> PostSimCart([FromBody]SimCartAdd model)
        {
            return await _simcartService.AddSimcart(model);
        }
    }
}