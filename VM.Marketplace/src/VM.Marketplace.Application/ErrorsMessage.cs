namespace VM.Marketplace.Application;

public class GroupErrorMessage
{
    public const string DescriptionIsRequired = "A descrição do grupo deve ser informada";
    public const string DescriptionMinLength = "A descrição deve ter no mínimo 3 caracteres";
    public const string DescriptionIdNotValid = "O ID do grupo informado não é válido";
    public const string GroupAlreadyExists = "Já existe um grupo cadastrado com essa descrição";
    public const string GroupNotFound = "O grupo solicitado não existe";
}
