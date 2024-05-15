namespace VM.Marketplace.Application.AppSettings;

public class JwtSettings
{
    public string SigningKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public Double TokenValidityInMinutes { get; set; }
}
