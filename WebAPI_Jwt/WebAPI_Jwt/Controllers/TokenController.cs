using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_Jwt.Models;

namespace WebAPI_Jwt.Controllers
{
    public class TokenController : Controller
    {
        [HttpPost]
        [Route("api/token/create")]
        public IActionResult Create([FromBody]LoginViewModel model)
        {
            //nesse exemlpo esta fixo aqui mas é só implementar o fluxo para buscar no banco de dados
            if (model.Email == "arthur.rafa10@gmail.com" && model.Password == "amdk@1990")
            {
                return new ObjectResult(GenerateToken(model.Email));
            }
            return BadRequest();
        }

        private string GenerateToken(string email)
        {
            var claims = new Claim[]
            {
                //define as claims 
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            //gera o token
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("senhasupersecretaparaauth"));
            SigningCredentials signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtHeader jwtHeader = new JwtHeader(signingCredential);
            JwtPayload jwtPayload = new JwtPayload(claims);
            JwtSecurityToken token = new JwtSecurityToken(jwtHeader, jwtPayload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}