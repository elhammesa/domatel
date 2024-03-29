﻿using System.Collections.Generic;
using System.Threading.Tasks;
using domatel.Models.Core;
using domatel.Models.Products;

namespace domatel.Interface.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<ServiceResult> AddProduct(Product model);
        Task<ServiceResult> EditProduct(int id, Product model);
        Task<ServiceResult<Product>> GetProductById(int id);

        Task<ServiceResult<List<Product>>> GetAllProduct();
    }
}