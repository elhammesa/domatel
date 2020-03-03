using System.Collections.Generic;
using System.Threading.Tasks;
using domatel.Models.Core;
using domatel.Models.Products;
using domatel.Models.SoldItems;

namespace domatel.Interface.Interfaces.Service
{
    public interface ISoldProductService
    {
        Task<ServiceResult> AddSoldItem(SoldItem model);
       
        Task<ServiceResult<Product>> GetSoldItemById(int id);

        Task<ServiceResult<List<Product>>> GetAllSoldItem();
    }
}