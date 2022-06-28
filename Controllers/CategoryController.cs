using BlogWebApi.Data;
using BlogWebApi.Models;
using BlogWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> Get(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> Post(
            [FromBody] CreateCategoryViewModel model,
            [FromServices] BlogDataContext context)
        {
            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}", category);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Não foi possível incluir a categoria.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha interna no servidor.");
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id,
            [FromBody] EditCategoryViewModel model,
            [FromServices] BlogDataContext context)
        {
            try
            {
                var category = context.Categories.SingleOrDefault(x => x.Id == id);

                if (category is null)
                {
                    return NotFound();
                }

                category.Name = model.Name;
                category.Slug = model.Slug;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Não foi possível alterar a categoria.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha interna no servidor.");
            }
        }


        [HttpDelete("v1/categories/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context.Categories.SingleOrDefaultAsync(x => x.Id == id);

                if (category is null)
                {
                    return NotFound();
                }

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Não foi possível alterar a categoria.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro ao deletar categoria.");
            }
        }
    }
}
