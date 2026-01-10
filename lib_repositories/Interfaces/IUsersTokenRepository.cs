using lib_domain.Entities;

namespace lib_repositories.Interfaces
{
    public interface IUsersTokenRepository
    {
        string? CreateCode(Users entity, string? code);
        bool CheckCode(string? data, string? code);
    }
}