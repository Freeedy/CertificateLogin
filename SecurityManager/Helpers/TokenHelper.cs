using Microsoft.IdentityModel.Tokens;
using SecurityManager.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SecurityManager.Helpers
{
    public class TokenHelper
    {
        private readonly string _issuer;

        public TokenHelper(string issuer)
        {
            _issuer = issuer;
        }

        public string GenerateSecureSecret()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }

        public string GenerateToken(TokenInput input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(input.Customer.Secret);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, input.NameIdentifier)
            };

            foreach (var item in input.Claims)
            {
                claims.Add(new Claim(item.Key, item.Value));
            }

            var claimsIdentity = new ClaimsIdentity();
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), input.Customer.SecurityAlgorithm);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = _issuer,
                Audience = input.Customer.Audience,
                Expires = DateTime.UtcNow.AddMinutes(input.Customer.Minutes),
                SigningCredentials = signingCredentials,
                IssuedAt = DateTime.UtcNow 
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
