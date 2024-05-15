using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Application.Interfaces;

public interface IJwtService
{
    Task<AuthenticationResultDto> GenerateToken(UserDto user);
}
