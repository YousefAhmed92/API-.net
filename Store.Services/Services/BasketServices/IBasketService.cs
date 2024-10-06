using Store.Repo.Basket.Models;
using Store.Services.Services.BasketServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketServices
{
    public interface IBasketService
    {
        Task<CustomerBasketDto> GetBasketAsync(string BasketId);
        Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto Basket);

        Task<bool> DeleteBasketAsync(string BasketId);
    }
}
