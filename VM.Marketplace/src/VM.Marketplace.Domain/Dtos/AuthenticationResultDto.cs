namespace VM.Marketplace.Domain.Dtos;

public class AuthenticationResultDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string PhoneNumber { get; set; }
    public string Token { get; set; }
    public IEnumerable<ClaimDto> Claims { get; set; }


    public AuthenticationResultDto(Guid id, string fullName, string email, 
        string role, string phoneNumber, string token, IEnumerable<ClaimDto> claims)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Role = role;
        PhoneNumber = phoneNumber;
        Token = token;
        Claims = claims;
    }
}