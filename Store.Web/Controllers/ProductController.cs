using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repo.Specifications.Product;
using Store.Services.Services;
using Store.Services.Services.Product.DTOs;
using Store.Web.Helper;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task <ActionResult<IReadOnlyList<BrandTypeDetailsDTO>>> GetAllBrands()
            => Ok (await _productService.GetAllBrandsAsync());



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDTO>>> GetAllTypes()
            => Ok(await _productService.GetAllTypesAsync());



        [HttpGet]
        [Cache(10)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDTO>>> GetAllProducts([FromQuery]ProductSpecification input)
            => Ok(await _productService.GetAllProductsAsync(input));



        [HttpGet]
        public async Task<ActionResult<ProductDetailsDTO>> getProductById(int? id)
            => Ok(await _productService.GetProductByIdAsync(id));



    }
}
