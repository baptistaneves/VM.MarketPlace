namespace VM.Marketplace.Infrastructure.Identity.Models;

public static class ClaimType
{
    public const string User = "Usuário";
    public const string Role = "Perfil";
    public const string Address = "Endereço";
    public const string DeliveryAddress = "Endereço de Entrega";
    public const string Category = "Categoria";
    public const string Subcategory = "Subcategoria";
    public const string Unit = "Unidade";
    public const string State = "Província";
    public const string City = "Munícipio";
    public const string Group = "Grupo";
}

public static class ClaimValue
{
    public const string View = "Visualizar";
    public const string Add = "Adicionar";
    public const string Update = "Actualizar";
    public const string Remove = "Remover";
    public const string Block = "Bloquear";
    public const string Unblock = "Desbloquear";
    public const string Reset = "Resetar Senha";
    public const string Change = "Alterar Senha";
}
