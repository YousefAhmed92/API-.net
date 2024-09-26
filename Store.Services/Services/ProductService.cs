using AutoMapper;
using Store.Data.Entities;
using Store.Repo.Interfaces;
using Store.Repo.Specifications.Product;
using Store.Services.Hepler;
using Store.Services.Services.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDTO>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.repo<ProductBrand, int>().GetAllAsNoTracking();
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDTO>>(brands);

            return mappedBrands;

        }

        public async Task<PaginatedResultDTO<ProductDetailsDTO>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecifications(input);


            var products = await _unitOfWork.repo<Store.Data.Entities.Product, int>().GetAllAsyncWithSpecification(specs);
            var mappedProducts = _mapper.Map <IReadOnlyList<ProductDetailsDTO>>(products);

            return new PaginatedResultDTO<ProductDetailsDTO>(input.PageSize, input.PageIndex , products.Count , mappedProducts);
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDTO>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.repo<ProductType, int>().GetAllAsNoTracking();
            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDTO>>(Types);

            return mappedTypes;
         }

        public async Task<ProductDetailsDTO> GetProductByIdAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("id is null");


            var specs = new ProductWithSpecifications(productId);


            var Product = await _unitOfWork.repo<Store.Data.Entities.Product, int>().GetByIdAsyncWithSpecification(specs);

            if (Product is null )
                throw new Exception("id is null");

            var mappedProduct = _mapper.Map<ProductDetailsDTO>(Product);

            return mappedProduct;
        }
    }
}
