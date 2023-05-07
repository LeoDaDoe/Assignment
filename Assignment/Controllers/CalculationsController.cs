using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/numbers")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        readonly IApiRequestProcessingService calculationsService;
        public CalculationsController(IApiRequestProcessingService calculationsService)
        {
            this.calculationsService = calculationsService;
        }

        [HttpPut("submitnumbers",Name = "SubmitNumbers")]
        public ActionResult SubmitNumbers([FromBody] string numbers)
        {
            try
            {
                calculationsService.ProcessNumbers(numbers);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("fetchlastsortresult",Name ="FetchLastSortResult")]
        public ActionResult FetchLastSortResult()
        {
            try
            {     
                return Ok(calculationsService.FetchLastSortResult());
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
