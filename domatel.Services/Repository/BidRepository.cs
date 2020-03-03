using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domatel.DataLayer.Data;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Models;
using domatel.Models.Bids;
using domatel.Models.Core;
using domatel.Services.Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace domatel.Services.Repository
{
  public  class BidRepository:IBidRepository
    {
        private DomatelContext _domatelContext;
        public BidRepository(DomatelContext domatelContext)

        {
            _domatelContext = domatelContext;
        }
        

        public async Task<ServiceResult> AddBid(Bid model)
        {
            try
            {
                await _domatelContext.Bids.AddAsync(model);
                await _domatelContext.SaveChangesAsync();
                return new ServiceResult
                {
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<string>> GetMaxPrice(int id)
        {
            try
            {
                var bid= _domatelContext.Bids.OrderByDescending(s => s.OfferPrice)
                    .FirstOrDefault(s => s.ProductId == id);


                if (bid != null)
                {
                    return new ServiceResult<string>
                    {
                        Data = JsonConvert.SerializeObject(bid.OfferPrice),
                        Message = string.Empty,
                        Status = (int)Configuration.ServiceResultStatus.Success
                    };
                }

                var product = _domatelContext.Products.FirstOrDefault(s => s.Id == id);

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(product.BasePrice),
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<string>
                {
                     Data = null,
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }
    }
}
