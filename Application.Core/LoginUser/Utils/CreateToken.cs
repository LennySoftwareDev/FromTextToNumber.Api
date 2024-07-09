using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Core.LoginUser.Utils;

public class CreateToken
{
    private readonly IConfiguration _configuration;

    public CreateToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string idUser)
    {
        var jwtKey = _configuration["JwtSettings:key"];
        var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

        var claims = new[]
        {
          new Claim(ClaimTypes.NameIdentifier, idUser)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

}
