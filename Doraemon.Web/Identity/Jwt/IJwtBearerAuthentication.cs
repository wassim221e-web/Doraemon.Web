using System.Security.Claims;

namespace Doraemon.Web.Identity.Jwt;

public interface IJwtBearerAuthentication
{
    string GenerateToken(IEnumerable<Claim> claims);
}