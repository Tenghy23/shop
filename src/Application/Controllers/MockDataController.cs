namespace Application.Controllers
{
    [ApiController]
    public class MockDataController : ApplicationBaseController
    {
        private readonly IMockDataService _mockDataService;

        public MockDataController(
            IMockDataService mockDataService
            )
        {
            _mockDataService = mockDataService;
        }

        [HttpPost("MockProductsAndInventory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MockProductsAndInventory(int count)
        {
            try
            {
                var response = await _mockDataService.MockProductsAndInventory(count);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InvalidResponse(ex);
            }
        }

        [HttpPost("MockCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MockCategory(int count)
        {
            try
            {
                var response = await _mockDataService.MockCategory(count);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InvalidResponse(ex);
            }
        }

        [HttpPost("MockAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MockAddress(int count)
        {
            try
            {
                var response = await _mockDataService.MockAddress(count);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InvalidResponse(ex);
            }
        }

    }
}
