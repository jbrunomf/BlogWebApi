using BlogWebApi.Models;
using BlogWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly TokenService _tokenService;
        public AccountController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [AllowAnonymous]
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
