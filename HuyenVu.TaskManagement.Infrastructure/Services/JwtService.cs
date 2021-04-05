using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HuyenVu.TaskManagement.Core.Models;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HuyenVu.TaskManagement.Infrastructure.Services
{
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GenerateJwtToken(UserInfoResponseModel user)
        {
            // create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.MobileNo)
            };
            
            //TODO: add roles to claims here

            
            // create IdentityClaims
            var identityClaims = new ClaimsIdentity(claims);
            
            // create tokenBuilder and generate the token
            var securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSettings:PrivateKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var expires = DateTime.UtcNow.AddHours(_configuration.GetValue<double>("TokenSettings:ExpirationHours"));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenObject = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["TokenSettings:Issuer"],
                Audience = _configuration["TokenSettings:Audience"],
            };

            var encodedJwt = tokenHandler.CreateToken(tokenObject);

            return tokenHandler.WriteToken(encodedJwt); 
        }
    }
}