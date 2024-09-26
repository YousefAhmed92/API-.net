using AutoMapper;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.Product.DTOs
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Store.Data.Entities.Product, ProductDetailsDTO>()
                .ForMember(dest => dest.PictureUrl, option => option.MapFrom<ProductPictureUrlSolver>());
            CreateMap<ProductType, BrandTypeDetailsDTO>();
            CreateMap<ProductBrand, BrandTypeDetailsDTO>();
            


        }

    }
}
