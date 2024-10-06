using AutoMapper;
using Store.Repo.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketServices.DTOs
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap <CustomerBasket,CustomerBasket>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

        }
    }
}
