using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration configuration)
        {
            this._config = configuration;
        }
        [HttpPost("admin-login")]
        public ActionResult<string> Login([FromBody] LoginDTO request)
        {
            // this needs to checked from DB
            if (request.Username == "admin" && request.Password == "password")
            {
                return Ok(new { token = generateJwtToken(request.Username, "Admin") });
            }
            return Unauthorized();
        }

        [HttpPost("user-login")]
        public ActionResult<string> LoginUser([FromBody] LoginDTO request)
        {
            // this needs to checked from DB
            if (request.Username == "admin" && request.Password == "password")
            {
                return Ok(new { token = generateJwtToken(request.Username, "User") });
            }
            return Unauthorized();
        }

        private string generateJwtToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Email","amdinkjfksdj@ccc.com"),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
