namespace Application.Controllers
{
    [ApiController]
    //[Route("[product]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductController(
            IProductRepository productRepository,
            IProductService productService
            )
        {
            _productRepository = productRepository;
            _productService = productService;
        }

        [HttpGet("getAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            var listOfProducts = await _productRepository.GetProductsAsync();
            var response = _productService.ConvertProductsToProductsDto(listOfProducts); // todo: return viewModel, not dto
            return Ok(response);
        }

        [HttpPost("getProductWithId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductWithId([FromBody] Guid id)
        {
            var response = await _productRepository.GetProductByIdAsync(id);
            if (response is null) { throw new ProductNotFoundException(id); }
            return Ok(response);
        }
    }
}
