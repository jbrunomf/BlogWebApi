using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")] // Health-check
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
