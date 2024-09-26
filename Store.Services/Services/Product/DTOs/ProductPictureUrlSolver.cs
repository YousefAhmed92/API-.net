using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.Product.DTOs
{
    public class ProductPictureUrlSolver : IValueResolver<Store.Data.Entities.Product,ProductDetailsDTO,String>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlSolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Data.Entities.Product source, ProductDetailsDTO destination, string destMember, ResolutionContext context)
        {
            if(! string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseUrl"]}/{source.PictureUrl}";

            return null;
        }
    }
}
