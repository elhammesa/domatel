using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Repository;
using domatel.Models.Core;
using domatel.Models.Products;

namespace domatel.Services.Repository
{
   public class ProductRepository:IProductRepository
    {
        public Task<ServiceResult> AddProduct(Product model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> EditProduct(int id, Product model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<Product>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<List<Product>>> GetAllProduct()
        {
            throw new NotImplementedException();
        }
    }
}
