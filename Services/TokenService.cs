using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BlogWebApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace BlogWebApi.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // Instanciando TokenHandler
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // Pegando a Key
            var tokenDescriptor = new SecurityTokenDescriptor(); // Criando especificacao do token
            var token = tokenHandler.CreateToken(tokenDescriptor); // Criando o token
            return tokenHandler.WriteToken(token); // Retornando o token com uma string.
        }
    }
}
