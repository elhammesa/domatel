using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Models;
using domatel.Models.Bids;
using domatel.Models.Core;
using domatel.Services.Utility;

namespace domatel.Services.Service
{
    class BidService:IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        public async Task<ServiceResult> AddBid(Bid model)
        {
          return await  _bidRepository.AddBid(model);
        }

        public Task<ServiceResult<string>> GetMaxPrice(int id)
        {
            return _bidRepository.GetMaxPrice(id);
        }
    }
}
