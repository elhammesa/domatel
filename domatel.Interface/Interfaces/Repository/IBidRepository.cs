using System.Collections.Generic;
using System.Threading.Tasks;
using domatel.Models;
using domatel.Models.Bids;
using domatel.Models.Core;
using domatel.Models.Products;

namespace domatel.Interface.Interfaces.Repository
{
    public interface IBidRepository

    {
        Task<ServiceResult> AddBid(Bid model);
        Task<ServiceResult<string>> GetMaxPrice(int id);




    }
}