using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.SignalR;

namespace Application.Controllers
{
    public class CSharpTopicsController : Controller
    {
        private readonly ICSharpTopicsService _cSharpTopicService;
        private readonly IHubContext<StockTickerHub> _hubContext;

        public CSharpTopicsController(
            ICSharpTopicsService cSharpTopicsService,
            IHubContext<StockTickerHub> hubContext
            )
        {
            _cSharpTopicService = cSharpTopicsService;
            _hubContext = hubContext;
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

        [HttpPost("AsyncParallelVsSynchronous")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AsyncParallelVsSynchronous()
        {
            var response = await _cSharpTopicService.AwaitVsSynchronousAsync();
            return Ok(response);
        }

        [HttpPost("MultithreadingSharedListMutate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MultithreadingSharedListMutate()
        {
            var response = await _cSharpTopicService.MultithreadingSharedListMutate();
            return Ok(response);
        }

        [HttpPost("FetchLiveStockPrices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FetchLiveStockPrices(string symbol)
        {
            var response = await _cSharpTopicService.FetchLiveStockPrices(symbol);
            return Ok(response);
        }

        //[HttpGet("api/stock/{symbol}")]
        //public async Task<IActionResult> GetStockData(string symbol)
        //{
        //    try
        //    {
        //        // Fetch the real-time stock data
        //        var stockData = await _cSharpTopicService.FetchLiveStockPrices(symbol);

        //        // Assuming stockData is already deserialized to a Stock object
        //        // Send the stock update to all connected clients
        //        //await _hubContext.Clients.All.SendAsync("ReceiveMessage", stockData.Symbol, stockData.Price);

        //        // Return the stock data as a response to the HTTP request
        //        return Ok(stockData);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        // Handle exceptions (e.g., stock not found, API errors)
        //        return StatusCode(500, ex.Message);
        //    }
        //}

    }
}
