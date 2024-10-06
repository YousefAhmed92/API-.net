using AutoMapper;
using Store.Repo.Basket; // Assuming this is the repository for baskets
using Store.Repo.Basket.Models;
using Store.Services.Services.BasketServices.DTOs;
using System;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepositary _basketRepository; // Replace IBasketService with IBasketRepository or the correct interface
        private readonly IMapper _mapper;

        public BasketService(IBasketRepositary basketRepository, IMapper mapper) // Inject the repository, not IBasketService
        {
            _basketRepository = basketRepository; // Correct assignment
            _mapper = mapper;
        }

        public async Task<bool> DeleteBasketAsync(string BasketId)
            => await _basketRepository.DeleteBasketAsync(BasketId); // Call the repository

        public async Task<CustomerBasketDto> GetBasketAsync(string BasketId)
        {
            var basket = await _basketRepository.GetBasketAsync(BasketId); // Call the repository
            if (basket == null)
                return new CustomerBasketDto();

            var mappedBasket = _mapper.Map<CustomerBasketDto>(basket);
            return mappedBasket;
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto Input)
        {
            if (Input.Id is null)
                Input.Id = GenerateRandomString();

            // Map DTO to the domain model (CustomerBasket)
            var customerBasket = _mapper.Map<CustomerBasket>(Input); // Mapping from DTO to domain model

            // Now, pass the domain model to the repository
            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket); // Update using domain model

            // Map the updated domain model back to DTO
            var mappedUpdatedBasket = _mapper.Map<CustomerBasketDto>(updatedBasket);

            return mappedUpdatedBasket;
        }


        private string GenerateRandomString()
        {
            Random random = new Random();
            int randomDigits = random.Next(1000, 10000);
            return $"BS-{randomDigits}-";
        }
    }
}
