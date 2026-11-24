using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Chess;

public class JwtService
{
    private const string SecretKey ="naneaghabekyan'sverysecretprotectedkeytogeneratejwt";




    public string GenerateToken(Player account)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("nickname", account.Nickname),
            new Claim("id", account.Id.ToString())
        };

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}