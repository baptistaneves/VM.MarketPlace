using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateCityRequest
{

    [Required(ErrorMessage = CityErrorMessage.NameIsRequired)]
    [MinLength(3, ErrorMessage = CityErrorMessage.NameMinLength)]
    public string Name { get; set; }

    [Required(ErrorMessage = CityErrorMessage.StateIsRequired)]
    public Guid StateId { get; set; }
}

public class UpdateCityRequest
{
    [Required(ErrorMessage = CityErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = CityErrorMessage.NameIsRequired)]
    [MinLength(3, ErrorMessage = CityErrorMessage.NameMinLength)]
    public string Name { get; set; }

    [Required(ErrorMessage = CityErrorMessage.StateIsRequired)]
    public Guid StateId { get; set; }
}