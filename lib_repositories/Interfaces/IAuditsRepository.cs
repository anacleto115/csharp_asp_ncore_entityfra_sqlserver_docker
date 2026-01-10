using lib_domain.Entities;

namespace lib_repositories.Interfaces
{    
    public interface IAuditsRepository
    {
        void Configurar(string StringConexion);
        Audits Insert(Audits entity);
    }
}