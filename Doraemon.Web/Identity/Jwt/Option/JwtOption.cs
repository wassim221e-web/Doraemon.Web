namespace Doraemon.Identity.Jwt.Option;

public class JwtOptions
{
    public const string Jwt = "jwt";

    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public TimeSpan Expire { get; set; }

}