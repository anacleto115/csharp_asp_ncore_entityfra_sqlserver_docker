using lib_domain.Entities;
using System.Collections.Generic;

namespace lib_repositories.Interfaces
{    
    public interface IProductsRepository
    {
        void Configurar(string StringConexion);
        List<Products> Select();
        List<Products> Where(Products entity);
        Products Insert(Products entity);
        Products Update(Products entity);
        Products Delete(Products entity);
    }
}