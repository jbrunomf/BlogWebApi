using BlogWebApi.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("v1/login")]
        public IActionResult Login()
        {
            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(null);

            return Ok(token);
        }
    }
}
