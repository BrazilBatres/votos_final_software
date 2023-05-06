using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAPIController : Controller
    {
        private readonly IConfiguration _config;

        public LoginAPIController(IConfiguration config)
        {
            _config = config;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<string> Login(string password)
        {
            string ToReturn = "Por favor ingresa la contraseña correcta ";
            try
            {
                if (password == "ingenieriaDeSoftware")//Aquí verificar que la contraseña y usuarios sean correctos
                {
                    
                    ToReturn = CustomTokenJWT(DateTime.Now.AddMinutes(30));
                }
            }
            catch (Exception ex)
            {
                ToReturn += ex.Message;
            }
            return ToReturn;
        }

        
        private string CustomTokenJWT(DateTime token_expiration)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])
                );

            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );

            var _Header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var _Payload = new JwtPayload(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.Now,
                    expires: token_expiration
                );

            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);

        }
    }
}
