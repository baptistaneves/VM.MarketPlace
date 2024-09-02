namespace VM.Marketplace.Domain.Results;

public class UserErrorMessage
{
    public const string FullNameIsRequired = "O nome completo deve ser informado";
    public const string AddressIsRequired = "O endereço deve ser informado";
    public const string DeliveryAddressIsRequired = "O endereço de entrega deve ser informado";
    public const string BankIsRequired = "O nome banco deve ser informado";
    public const string AccountNumberIsRequired = "A conta bancária deve ser informada";
    public const string AccountHolderIsRequired = "O nome da conta deve ser informado";
    public const string IbanIsRequired = "O IBAN deve ser informado";
    public const string CityIsRequired = "O munícipio deve ser informado";
    public const string StateIsRequired = "A província deve ser informada";
    public const string IdNotValid = "O ID do utilizador informado não é válido";
    public const string RoleIsRequired = "O perfil do utilizador deve ser informado";
    public const string EmailIsRequired = "O e-mail deve ser informado";
    public const string PhoneNumberIsRequired = "O telefone deve ser informado";
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

public class RoleErrorMessage
{
    public const string NameIsRequired = "O nome do perfil deve ser informado";
    public const string NameMinLength = "O nome deve ter no mínimo 3 caracteres";
    public const string IdNotValid = "O ID do perfil informado não é válido";
    public const string RoleAlreadyExists = "Já existe um perfil cadastrado com esse nome";


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
    public const string ImageUrlIsRequired = "Seleccione a imagem desta tegoria";

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

public class ProductErrorMessage
{
    public const string NameIsRequired = "O nome do produto deve ser informado";
    public const string DescriptionIsRequired = "Informe uma descrição para este produto";
    public const string CategoryIsRequired = "Seleccione a categoria deste produto";
    public const string PhotoIsRequired = "Seleccione uma foto para este produto";
    public const string PriceIsRequired = "O preço do produto deve ser informado";
    public const string PriceMustBeGreaterThan = "O valor do preço do produto deve ser mair que 0";
    public const string ExpiryDateRequired = "A data de expiração deve ser informada para produtos medicinais";
    public const string IdNotValid = "O ID do produto informado não é válido";
    public const string ProductNotFound = "O produto solicitado não foi encontrado";
}

public class CommentsErrorMessage
{
    public const string TextIsRequired = "Informe o texto do comentário";
    public const string ProductIdIsRequired = "O produto não foi informado";
    public const string UserNameIsRequired = "O nome do usuário deve ser informado";
    public const string UserEmailIsRequired = "O email do usuário deve ser informado";
}