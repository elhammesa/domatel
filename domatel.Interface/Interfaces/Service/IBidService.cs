using System.Collections.Generic;
using System.Threading.Tasks;
using domatel.Models;
using domatel.Models.Bids;
using domatel.Models.Core;

namespace domatel.Interface.Interfaces.Service
{
    public interface IBidService
    {
   
        Task<ServiceResult> AddBid(Bid model);
        Task<ServiceResult<string>> GetMaxPrice(int id);

    }
}