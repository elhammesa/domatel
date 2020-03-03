using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
using domatel.Models.Products;
using domatel.Models.SoldItems;

namespace domatel.Services.Service
{
    class SoldItemService:ISoldProductService
    {
        public Task<ServiceResult> AddSoldItem(SoldItem model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<Product>> GetSoldItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<List<Product>>> GetAllSoldItem()
        {
            throw new NotImplementedException();
        }
    }
}
