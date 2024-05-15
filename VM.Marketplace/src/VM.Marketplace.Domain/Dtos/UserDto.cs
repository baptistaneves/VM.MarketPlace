using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Domain.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public TypeUser Type { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public string PhotoUrl { get; set; }
    public string Address { get; set; }
    public string DeliveryAddress { get; set; }
    public string VatNumber { get; set; }
    public string Bank { get; set; }
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string Iban { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsBlocked { get; set; }
}