using lib_domain.Entities;
using System.Collections.Generic;

namespace lib_repositories.Interfaces
{    
    public interface ITypesRepository
    {
        void Configurar(string StringConexion);
        List<Types> Select();
        List<Types> Where(Types entity);
        Types Insert(Types entity);
        Types Update(Types entity);
        Types Delete(Types entity);
    }
}