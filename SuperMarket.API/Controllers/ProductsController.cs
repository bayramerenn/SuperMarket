using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Concrete;
using SuperMarket.Core.Dtos;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto product)
        {
            var result = await _productService.SaveAsync(product);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}