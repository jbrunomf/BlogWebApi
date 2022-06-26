using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("categories")]
        public IActionResult Get(
            [FromServices] BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }
    }
}
