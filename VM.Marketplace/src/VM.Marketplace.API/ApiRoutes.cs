namespace VM.Marketplace.API;

public class ApiRoutes
{
    public const string BaseRoute = "api/v{version:ApiVersion}/[controller]";

    public static class User
    {
        public const string AddAdminUser = "adicionar-usuario-admin";
        public const string GetAllAdminUsers = "obter-usuarios-admin";
        public const string RemoveUserAdmin = "remover-usuario-admin/{id}";
        public const string UpdateUserAdmin = "actualizar-usuario-admin";
    }

    public static class Role
    {
        public const string Add = "adicionar-perfil";
        public const string Update = "actualizar-perfil";
        public const string Remove = "remover-perfil/{id}";
        public const string GetAll = "obter-perfis";
        public const string GetRoleClaims = "obter-permissoes-de-perfil";
        public const string GetById = "obter-perfil-por-id/{id}";
    }

    public static class Group
    {
        public const string Add = "adicionar-grupo";
        public const string Update = "actualizar-grupo";
        public const string Remove = "remover-grupo/{id}";
        public const string GetAll = "obter-grupos";
        public const string GetById = "obter-grupo-por-id/{id}";
    }

    public static class Unit
    {
        public const string Add = "adicionar-unidade";
        public const string Update = "actualizar-unidade";
        public const string Remove = "remover-unidade/{id}";
        public const string GetAll = "obter-unidades";
        public const string GetById = "obter-unidade-por-id/{id}";
    }

    public static class Category
    {
        public const string Add = "adicionar-categoria";
        public const string Update = "actualizar-categoria";
        public const string Remove = "remover-categoria/{id}";
        public const string GetAll = "obter-categorias";
        public const string GetById = "obter-categoria-por-id/{id}";
    }

    public static class Subcategory
    {
        public const string Add = "adicionar-subcategoria";
        public const string Update = "actualizar-subcategoria";
        public const string Remove = "remover-subcategoria/{id}";
        public const string GetAll = "obter-subcategorias";
        public const string GetSubcategoriesByCategoryId = "obter-subcategorias-por-categoria/{categoryId}";
        public const string GetById = "obter-subcategoria-por-id/{id}";
    }

    public static class State
    {
        public const string Add = "adicionar-provincia";
        public const string Update = "actualizar-provincia";
        public const string Remove = "remover-provincia/{id}";
        public const string GetAll = "obter-provincias";
        public const string GetById = "obter-provincia-por-id/{id}";
    }

    public static class City
    {
        public const string Add = "adicionar-municipio";
        public const string Update = "actualizar-municipio";
        public const string Remove = "remover-municipio/{id}";
        public const string GetAll = "obter-municipios";
        public const string GetCitiesByStateId = "obter-municipios-por-provincia/{stateId}";
        public const string GetById = "obter-municipio-por-id/{id}";
    }

    public static class Address
    {
        public const string Add = "adicionar-endereco";
        public const string Update = "actualizar-endereco";
        public const string Remove = "remover-endereco/{id}";
        public const string GetAll = "obter-enderecos";
        public const string GetById = "obter-endereco-por-id/{id}";
    }

    public static class DeliveryAddress
    {
        public const string Add = "adicionar-endereco-de-entrega";
        public const string Update = "actualizar-endereco-de-entrega";
        public const string Remove = "remover-endereco-de-entrega/{id}";
        public const string GetAll = "obter-enderecos-de-entrega";
        public const string GetById = "obter-endereco-de-entrega-por-id/{id}";
    }
}
