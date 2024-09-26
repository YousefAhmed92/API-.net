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
    public interface IProductService
    {
        Task<ProductDetailsDTO> GetProductByIdAsync(int? productId);
        Task<PaginatedResultDTO<ProductDetailsDTO>> GetAllProductsAsync(ProductSpecification specs);
        Task<IReadOnlyList<BrandTypeDetailsDTO>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDTO>> GetAllTypesAsync();

    }
}
