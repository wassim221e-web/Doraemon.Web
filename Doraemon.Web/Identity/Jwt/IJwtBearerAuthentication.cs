using System.Security.Claims;

namespace Doraemon.Identity.Jwt;

public interface IJwtBearerAuthentication
{
    string GenerateToken(IEnumerable<Claim> claims);
}