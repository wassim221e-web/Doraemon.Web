using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Doraemon.Web.Identity.Jwt.Option;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Doraemon.Web.Identity.Jwt;

public class JwtBearerAuthentication:IJwtBearerAuthentication
{
    private readonly JwtOptions _jwtOption;

    public JwtBearerAuthentication(IOptions<JwtOptions>?jwtOptions=null)
    {
        _jwtOption = jwtOptions?.Value??new JwtOptions();
    }
    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(_jwtOption.Issuer,
            _jwtOption.Audience,
            claims,
            expires: DateTime.Now.Add(_jwtOption.Expire),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}