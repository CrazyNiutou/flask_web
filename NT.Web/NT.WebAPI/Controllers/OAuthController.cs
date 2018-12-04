using HT.Framework.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NT.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class OAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public string Get()
        {
            return "test";
        }
        [HttpPost]
        public IActionResult Post(string userName, string pwd)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName)
            };

            var configKey = ConfigHelper.GetSite("SecurityKey");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "jwttest",
                audience: "jewtest",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
