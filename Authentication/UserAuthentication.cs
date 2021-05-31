using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.IServices;
using Talbat.Models;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Authentication
{
    abstract public class UserAuthentication
    {
        public static string CreateToken (string email)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretey@83"));
            var siginingCerdentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken
                (
                 issuer: "https://localhost:4200",
                 audience: "https://localhost:4200",
                 claims: new List<Claim>()
                 {
                         new Claim(ClaimTypes.Email, email),
                 },
                 expires: DateTime.Now.AddMinutes(10),
                 signingCredentials: siginingCerdentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
