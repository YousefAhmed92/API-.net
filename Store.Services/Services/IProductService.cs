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
        Task<IReadOnlyList<ProductDetailsDTO>> GetAllProductsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDTO>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDTO>> GetAllTypesAsync();

    }
}
