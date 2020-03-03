using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Bids;
using domatel.Models.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace domatell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpGet("GetMaxPrice/{id}")]
        public async Task<ServiceResult<string>> GetMaxPrice(int id)
        {
            return await _bidService.GetMaxPrice(id);
        }


        [HttpPost]
        [Route("PostBid")]
        public async Task<ServiceResult> PostBid(Bid model)
        {
            return await _bidService.AddBid(model);
        }


    }

}