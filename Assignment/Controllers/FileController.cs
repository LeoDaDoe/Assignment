using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {

        readonly ICalculationsService calculationsService;
        public FileController(ICalculationsService calculationsService)
        {
            this.calculationsService = calculationsService;
        }

        [HttpGet("fetchfile")]
        public ActionResult FetchLastFile()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
