using BlogWebApi.Data;
using BlogWebApi.Extensions;
using BlogWebApi.Models;
using BlogWebApi.Services;
using BlogWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace BlogWebApi.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly TokenService _tokenService;
        public AccountController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [AllowAnonymous]
        [HttpPost("v1/accounts")]
        public async Task<IActionResult> Post(
            [FromBody] RegisterViewModel model,
            [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
                
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };

            var password = PasswordGenerator.Generate(25);
            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<dynamic>(new
                {
                    user = user.Email, password
                }));
            }
            catch (DbUpdateException e)
            {
                return StatusCode(400, value: new ResultViewModel<string>("Erro."));
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpPost("v1/login")]
        public IActionResult Login()
        {
            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(null);

            return Ok(token);
        }


        [Authorize(Roles = "user")]
        [HttpGet("v1/user")]
        public IActionResult GetUser() => Ok(User.Identity.Name);
        
        [Authorize(Roles = "author")]
        [HttpGet("v1/author")]
        public IActionResult GetAuthor() => Ok(User.Identity.Name);

        [Authorize(Roles = "admin")]
        [HttpGet("v1/admin")]
        public IActionResult GetAdmin() => Ok(User.Identity.Name);


    }
}
