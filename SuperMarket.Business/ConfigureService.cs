using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Concrete;
using SuperMarket.DataAccess.Context;
using SuperMarket.DataAccess.Repositories.Abstract;
using SuperMarket.DataAccess.Repositories.Concrete;
using SuperMarket.Entities.Models;
using System.Reflection;

namespace SuperMarket.Business
{
    public static class ConfigureService
    {
        public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SuperMarket.API"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddFluentValidationAutoValidation()
                  .AddFluentValidationClientsideAdapters()
                  .AddValidatorsFromAssemblyContaining(typeof(ConfigureService));

            return services;
        }
    }
}