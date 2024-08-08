using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Infrastructure
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
        private readonly IConfiguration configuration = configuration;

        public string GenerateToken(User user)
        {
            var signinCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSecret"])),
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaims(user),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signinCredentials
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GetClaims(User user) =>
            new(
                [
                 new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new(ClaimTypes.Email, user.Email),
                ]
                );
    }
}
