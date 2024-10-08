using Microsoft.AspNetCore.Mvc;
using Store.Repo.Interfaces;
using Store.Repo.Repos;
using Store.Services.Services.Product.DTOs;
using Store.Services.Services;
using Store.Services.HandleResponses;
using Store.Services.Services.CacheService;
using Store.Services.Services.BasketServices;
using Store.Repo.Basket;
using Store.Services.TokenService;
using Store.Services.UserService;

namespace Store.Web.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketRepositary, BasketRepositary>();
            services.AddScoped<ITokenService, TokenService>();


            services.AddScoped<ICacheService, CacheService>();

            services.AddAutoMapper(typeof(ProductProfile));
             
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                .Where(model => model.Value?.Errors.Count > 0)
                                .SelectMany(model => model.Value.Errors)
                                .Select(error => error.ErrorMessage)
                                .ToList();

                    var ErrorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(ErrorResponse);

                };
            });
            return services;
        }
    }
}
