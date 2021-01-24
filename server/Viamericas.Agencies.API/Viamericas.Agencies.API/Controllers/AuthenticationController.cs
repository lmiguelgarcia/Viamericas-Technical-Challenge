using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Viamericas.Agencies.Business.Interfaces;
using Viamericas.Agencies.Entity.Dto;

namespace Viamericas.Agencies.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Properties
        private readonly IConfiguration _configuration;
        private readonly IUserBusiness _business;
        #endregion
        #region Constructor
        public AuthenticationController(IConfiguration configuration, IUserBusiness business)
        {
            _configuration = configuration;
            _business = business;
        }
        #endregion
        #region Methods
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                if (_business.ValidateUser(model))
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    var authSiginKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Issuer"],
                        expires: DateTime.Now.AddDays(1),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSiginKey, SecurityAlgorithms.HmacSha256Signature)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        ValidTo = token.ValidTo.ToString("yyyy-MM-ddThh:mm:ss")
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
        #endregion
    }
}