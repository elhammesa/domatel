using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Models.Core;
using domatel.Models.Products;

namespace domatel.Services.Service
{
   public class ProductService:IProductService
   {
       private IProductRepository _productRepository;
        public async Task<ServiceResult> AddProduct(Product model)
        {
            return await _productRepository.AddProduct(model);
        }

        public async Task<ServiceResult> EditProduct(int id, Product model)
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
