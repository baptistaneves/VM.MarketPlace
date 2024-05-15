using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VM.Marketplace.Application.AppSettings;
using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Application.Services;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IRoleRepository _roleRepository;

    public JwtService(IOptions<JwtSettings> jwtSettings,
                      IRoleRepository roleRepository)
    {
        _jwtSettings = jwtSettings.Value;
        _roleRepository = roleRepository;
    }

    public async Task<AuthenticationResultDto> GenerateToken(UserDto user)
    {
        var role = await _roleRepository.GetRoleByName(user.Role);

        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                         SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GereateClaims(user, role.Claims),
            Expires = DateTime.Now.AddMinutes(_jwtSettings.TokenValidityInMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = signingCredentials,

        };

        var createToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(createToken);

        return new AuthenticationResultDto(
            user.Id,
            user.FullName,
            user.Email,
            user.Role,
            user.PhoneNumber,
            token,
            role.Claims
            );
    }

    private ClaimsIdentity GereateClaims(UserDto user, IEnumerable<ClaimDto> claims)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim("IdentityUserId", user.Id.ToString()));
        claimsIdentity.AddClaim(new Claim("Email", user.Email));
        claimsIdentity.AddClaim(new Claim("FullName", user.FullName));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

        foreach (var claim in claims)
        {
            claimsIdentity.AddClaim(new Claim(claim.Type, claim.Value));
        }

        return claimsIdentity;
    }
}
