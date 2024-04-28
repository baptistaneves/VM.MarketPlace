using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateDeliveryAddressRequest
{
    [Required(ErrorMessage = AddressErrorMessage.CityIsRequired)]
    public Guid CityId { get; set; }

    [Required(ErrorMessage = AddressErrorMessage.DescriptionIsRequired)]
    [MinLength(10, ErrorMessage = AddressErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    public string Street { get; set; }
}

public class UpdateDeliveryAddressRequest
{
    [Required(ErrorMessage = AddressErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = AddressErrorMessage.CityIsRequired)]
    public Guid CityId { get; set; }

    [Required(ErrorMessage = AddressErrorMessage.DescriptionIsRequired)]
    [MinLength(10, ErrorMessage = AddressErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    public string Street { get; set; }
}