using Store.Repo.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketServices.DTOs
{
    public class CustomerBasketDto
    {
        public string? Id { get; set; }
        public int? DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItemDto> basketItems { get; set; } = new List<BasketItemDto>();

    }
}
