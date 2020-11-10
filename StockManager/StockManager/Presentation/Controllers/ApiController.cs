using Microsoft.AspNetCore.Mvc;

namespace StockManager.Presentation.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        public ApiController()
        {
        }

        protected IActionResult SendOkResponse(object reuslt = null)
        {
            return Ok(reuslt);
        }

        protected IActionResult SendErrorResponse(string messageError = null)
        {
            return BadRequest(new
            {
                messageError
            });
        }
    }
}
