using System;

namespace Application.Controllers
{
    [ApiController]
    //[Route("[product]")]
    public class ProductController : ApplicationBaseController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        [HttpGet("getAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = await _productRepository.GetProductByIdAsync(Guid.NewGuid());
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return InvalidResponse(ex);
            }
        }

        [HttpPost("getProductWithId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductWithId([FromBody] Guid id)
        {
            try
            {
                var response = await _productRepository.GetProductByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InvalidResponse(ex);
            }
        }
    }
}
