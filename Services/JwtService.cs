using EDSystem.Models;
using EDSystem.Services.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EDSystem.Services
{
    public class JwtService : IJwt
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            //read values from app settings
            var secretKey = _configuration.GetSection("JwtOptions:SecretKey").Value;
            var audience = _configuration.GetSection("JwtOptions:Audience").Value; 
            var issuer = _configuration.GetSection("JwtOptions:Issuer").Value;

            //pass secret-key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //creds for security algorithm used
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //payload
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Roles", user.Roles));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Name));

            var tokendescriptor = new SecurityTokenDescriptor()
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddHours(5),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokendescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
