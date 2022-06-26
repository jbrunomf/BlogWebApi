using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            [FromServices] BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }
    }
}
