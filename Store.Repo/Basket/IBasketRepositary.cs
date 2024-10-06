using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Repo.Basket.Models;

namespace Store.Repo.Basket
{
    public interface IBasketRepositary
    {
        Task <CustomerBasket> GetBasketAsync (string BasketId);
        Task <CustomerBasket> UpdateBasketAsync (CustomerBasket Basket);

        Task <bool> DeleteBasketAsync (string BasketId);

    }
}
