using System.Linq;
using Core.Inferace;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using skinet.API.Errors;
using skinet.Core.Inferace;
using skinet.Infrastructure.Data;
using skinet.Infrastructure.Data.Migrations;
using skinet.Infrastructure.Services;

namespace skinet.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Cache service
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            //JWT token
            services.AddScoped<ITokenService, TokenService>();

            //Order service.
            services.AddScoped<IOrderService, OrderService>();

            //Adding payment service
            services.AddScoped<IPaymentService, PaymentService>();

            //Unit of work service.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Adding repository pattern as a service that can be called anywhere in the app.
            services.AddScoped<IProductRepository, ProductRepository>();
            //Adding service as a service that enables Basket repository as a service.
            services.AddScoped<IBasketRepository, BasketRepository>();
            //Adding generic repositories
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.Configure<ApiBehaviorOptions>(options => {options.InvalidModelStateResponseFactory = actionContext => 
            {
                var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
              };
            });
            return services;
        }
    }
}