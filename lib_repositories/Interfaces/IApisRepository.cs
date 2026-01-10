using System.Collections.Generic;

namespace lib_repositories.Interfaces
{    
    public interface IApisRepository
    {
        void Configurar(string StringConexion);
        Dictionary<string, object> Select();
    }
}