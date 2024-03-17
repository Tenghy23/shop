using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class CSharpTopicsController : ApplicationBaseController
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
            try
            {
                var response = await _cSharpTopicService.StreamWriteIntoTxtFile();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InvalidResponse(ex);
            }
        }

        [HttpPost("StreamWriteIntoExcelFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StreamWriteIntoExcelFile()
        {
            try
            {
                var response = await _cSharpTopicService.StreamWriteIntoExcelFile();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InvalidResponse(ex);
            }
        }

    }
}
