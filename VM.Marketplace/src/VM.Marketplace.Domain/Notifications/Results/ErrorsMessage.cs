namespace VM.Marketplace.Domain.Results;

public class UserErrorMessage
{
    public const string FullNameIsRequired = "O nome completo deve ser informado";
    public const string EmailIsRequired = "O e-mail deve ser informado";
    public const string VatNumberIsRequired = "O número de contribuinte deve ser informado";
    public const string PasswordIsRequired = "A senha deve ser informada";
    public const string PasswordMinLength = "A senha deve no mínimo 6 caracteres";
    public const string FullNameMinLength = "O nome deve ter no mínimo 3 caracteres";
    public const string EmailNotValid = "O e-mail informado não é válido";
    public const string UserEmailAlreadyExists = "Já existe um usuário cadastrado com esse e-mail";
    public const string UserNotFound = "O usuário solicitado não foi encontrado";
    public const string IncorretEmailOrPassword = "E-mail ou senha errada. Tente novamente";
    public const string LockoutFailure = "Usuário temporariamente bloqueado por tentativas inválidas. Tente novamente dentro de 5 minutos";
}

public class GroupErrorMessage
{
    public const string DescriptionIsRequired = "A descrição do grupo deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 3 caracteres";
    public const string DescriptionIdNotValid = "O ID do grupo informado não é válido";
    public const string GroupAlreadyExists = "Já existe um grupo cadastrado com essa descrição";
    public const string GroupNotFound = "O grupo solicitado não existe";
}

public class CategoryErrorMessage
{
    public const string DescriptionIsRequired = "A descrição da categoria deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 3 caracteres";
    public const string IdNotValid = "O ID da categoria informada não é válido";
    public const string CategoryAlreadyExists = "Já existe uma categoria cadastrada com essa descrição";
    public const string CategoryNotFound = "A categoria solicitada não existe";
    public const string GroupIsRequired = "O grupo da categoria deve ser informado";

}

public class SubcategoryErrorMessage
{
    public const string DescriptionIsRequired = "A descrição da subcategoria deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 3 caracteres";
    public const string IdNotValid = "O ID da subcategoria informada não é válido";
    public const string SubcategoryAlreadyExists = "Já existe uma subcategoria cadastrada com essa descrição";
    public const string SubcategoryNotFound = "A subcategoria solicitada não foi encontrada";
    public const string CategoryIsRequired = "A categoria deve ser informado";
}

public class UnitErrorMessage
{
    public const string DescriptionIsRequired = "A descrição da unidade deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 3 caracteres";
    public const string IdNotValid = "O ID da unidade informada não é válido";
    public const string UnitAlreadyExists = "Já existe uma unidade cadastrada com essa descrição";
    public const string UnitNotFound = "A unidade solicitada não foi encontrada";
}

public class StateErrorMessage
{
    public const string NameIsRequired = "O nome da província deve ser informado";
    public const string NameMinLength = "O nome deve ter no mínimo 3 caracteres";
    public const string IdNotValid = "O ID da província informado não é válido";
    public const string StateAlreadyExists = "Já existe uma província cadastrada com esse nome";
    public const string StateNotFound = "A província solicitada não foi encontrada";
}

public class CityErrorMessage
{
    public const string NameIsRequired = "O nome do munícipio deve ser informado";
    public const string NameMinLength = "O nome deve ter no mínimo 3 caracteres";
    public const string IdNotValid = "O ID do munícipio informado não é válido";
    public const string CityAlreadyExists = "Já existe um munícipio cadastrado com esse nome";
    public const string CityNotFound = "O munícipio solicitado não foi encontrado";
    public const string StateIsRequired = "A província deve ser informada";
}

public class AddressErrorMessage
{
    public const string DescriptionIsRequired = "A descrição do endereço deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 10 caracteres";
    public const string IdNotValid = "O ID do endereço informado não é válido";
    public const string AddessAlreadyExists = "Já existe um endereço cadastrado com essa descrição";
    public const string AddressNotFound = "O endereço solicitado não foi encontrado";
    public const string CityIsRequired = "O munícipio deve ser informado";
}

public class DeliveryAddressErrorMessage
{
    public const string DescriptionIsRequired = "A descrição do endereço deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 10 caracteres";
    public const string IdNotValid = "O ID do endereço informado não é válido";
    public const string DeliveryAddessAlreadyExists = "Já existe um endereço cadastrado com essa descrição";
    public const string DeliveryAddressNotFound = "O endereço solicitado não foi encontrado";
    public const string CityIsRequired = "O munícipio deve ser informado";
}