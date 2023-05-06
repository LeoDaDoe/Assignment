using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/numbers")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        readonly ICalculationsService calculationsService;
        public CalculationsController(ICalculationsService calculationsService)
        {
            this.calculationsService = calculationsService;
        }

        [HttpPut("submitnumbers",Name = "submitnumbers")]
        public ActionResult SubmitNumbers([FromBody] string numbers)
        {
            try
            {
                calculationsService.ProcessNumbers(numbers);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
