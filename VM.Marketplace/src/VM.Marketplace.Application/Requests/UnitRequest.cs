using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateUnitRequest
{
    [Required(ErrorMessage = UnitErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = UnitErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }
}

public class UpdateUnitRequest
{
    [Required(ErrorMessage =UnitErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = UnitErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = UnitErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }
}
