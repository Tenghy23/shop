namespace Application.Controllers
{
    public class CSharpTopicsController : Controller
    {
        private readonly ICSharpTopicsService _cSharpTopicService;

        public CSharpTopicsController(
            ICSharpTopicsService cSharpTopicsService
            )
        {
            _cSharpTopicService = cSharpTopicsService;
        }

        [HttpPost("StreamWriteIntoTxtFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StreamWriteIntoTxtFile()
        {
            var response = await _cSharpTopicService.StreamWriteIntoTxtFile();
            return Ok(response);
        }

        [HttpPost("StreamReadFromTxtFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StreamReadFromTxtFile()
        {
            var response = await _cSharpTopicService.StreamReadFromTxtFile();
            return Ok(response);
        }

        [HttpPost("StreamWriteIntoExcelFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StreamWriteIntoExcelFile()
        {
            var response = await _cSharpTopicService.StreamWriteIntoExcelFile();
            return Ok(response);
        }

        [HttpPost("StreamReadFromExcelFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StreamReadFromExcelFile()
        {
            var response = await _cSharpTopicService.StreamReadFromExcelFile();
            return Ok(response);
        }

        [HttpPost("MultithreadingVsSynchronous")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MultithreadingVsSynchronous()
        {
            var response = await _cSharpTopicService.MultithreadingVsSynchronous();
            return Ok(response);
        }

    }
}
