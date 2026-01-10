using lib_domain.Entities;
using lib_repositories.Interfaces;
using System;

namespace lib_repositories.Implementations
{
    public class AuditsRepository : IAuditsRepository
    {
        private IConnection? IConnection = null;

        public AuditsRepository(IConnection iConnection)
        {
            this.IConnection = iConnection;
        }

        public void Configurar(string StringConexion)
        {
            this.IConnection!.StringConexion = StringConexion;
        }

        public Audits Insert(Audits entity)
        {
            if (entity == null)
                throw new Exception("lbMissingInformation");

            if (entity.id != 0)
                throw new Exception("lbWasSaved");

            this.IConnection!.Audits!.Add(entity);
            this.IConnection!.SaveChanges();
            return entity;
        }
    }
}
