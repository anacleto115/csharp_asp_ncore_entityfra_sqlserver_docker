using lib_domain.Entities;
using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using ut_presentation.Core;
using System.Collections.Generic;

namespace ut_presentation.Connections
{
    [TestClass]
    public class AuditsTest
    {
        private readonly IConnection? iConnection;
        private List<Audits>? list;
        private Audits? entidad;

        public AuditsTest()
        {
            iConnection = new Connection();
            iConnection.StringConexion = Configuration.Get("StringConexion");
        }

        [TestMethod]
        public void Execute()
        {
            Assert.IsTrue(Insert());
        }

        public bool Insert()
        {
            this.entidad = EntitiesCore.Audits()!;
            this.iConnection!.Audits!.Add(this.entidad);
            this.iConnection!.SaveChanges();
            return true;
        }
    }
}