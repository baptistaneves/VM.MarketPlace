using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class RoleRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = RoleErrorMessage.NameIsRequired)]
    [MinLength(3, ErrorMessage = RoleErrorMessage.NameMinLength)]
    public string Name { get; set; }

    public List<ClaimRequest> Claims { get; set; } = new List<ClaimRequest>();
}

public class ClaimRequest
{
    public string Type { get; set; }
    public string Value { get; set; }
}
