using StackExchange.Redis;
using Store.Repo.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repo.Basket
{
    public class BasketRepositary : IBasketRepositary
    {
        private readonly IDatabase _database;

        public BasketRepositary(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }


        public async Task<bool> DeleteBasketAsync(string BasketId)
            => await _database.KeyDeleteAsync(BasketId);
        

        public async Task<CustomerBasket> GetBasketAsync(string BasketId)
        {
            var Basket = await _database.StringGetAsync(BasketId);
            return Basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket Basket)
        {
            var IsCreated = await _database.StringSetAsync(Basket.Id, JsonSerializer.Serialize(Basket), TimeSpan.FromDays(30));
            if (!IsCreated) return null;

            return await GetBasketAsync(Basket.Id);
        }
    }
}
