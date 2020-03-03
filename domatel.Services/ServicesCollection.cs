using System;
using System.Collections.Generic;
using System.Text;
using domatel.Interface;
using domatel.Interface.Interfaces.Repository;
using domatel.Interface.Interfaces.Service;
using domatel.Services.Repository;
using domatel.Services.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace domatel.Services
{
  public static class  ServicesCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ISimcartRepository, SimcartRepository>();
            services.AddScoped<ISimcartService, SimcartService>();
            services.AddScoped<IDomainRepository, DomainRepository>();
            services.AddScoped<IDomainService, DomainService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<ISoldProductRepository, SoldItemRepository>();
            services.AddScoped<ISoldProductService, SoldItemService>();
            //services.AddScoped<IAccountService, AccountService>();





            return services;
        }
    }
}
