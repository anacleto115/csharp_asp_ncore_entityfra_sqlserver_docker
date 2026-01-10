using lib_domain.Entities;
using System.Collections.Generic;

namespace lib_repositories.Interfaces
{
    public interface IUsersRepository
    {
        void Configurar(string StringConexion);
        List<Users> Select();
        List<Users> Where(Users entity);
        Users Insert(Users entity);
        Users Update(Users entity);
        Users Delete(Users entity);
    }
}