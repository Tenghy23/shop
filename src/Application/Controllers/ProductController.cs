namespace Application.Controllers
{
    [ApiController]
    [Route("[product]")]
    public class ProductController : ApplicationBaseController
    {
        [HttpPost("getAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = true; // to update
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return InvalidResponse(ex);
            }
        }
    }
}
