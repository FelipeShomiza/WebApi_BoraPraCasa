using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CorridaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Email == "admin@email.com" && request.Senha == "123456")
            {
                var token = GerarToken(request.Email);
                return Ok(new { token });
            }

            return Unauthorized("E-mail ou senha inválidos");
        }

        [Authorize]
        [HttpGet("protegido")]
        public IActionResult Protegido()
        {
            return Ok("Você acessou um endpoint protegido com JWT!");
        }

        private string GerarToken(string email)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("minha-chave-super-secreta-para-jwt-123456")
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, "Usuário Teste")
            };

            var token = new JwtSecurityToken(
                issuer: "CorridaAPI",
                audience: "CorridaFrontend",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}