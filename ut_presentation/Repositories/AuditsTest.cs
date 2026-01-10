using lib_domain.Entities;
using lib_repositories.Implementations;
using lib_repositories.Interfaces;
using System.Collections.Generic;
using ut_presentation.Core;

namespace ut_presentation.Repositories
{
    [TestClass]
    public class AuditsTest
    {
        private readonly IAuditsRepository? IRepository;
        private List<Audits>? list;
        private Audits? entidad;

        public AuditsTest()
        {
            var iConnection = new Connection();
            iConnection.StringConexion = Configuration.Get("StringConexion");
            
            IRepository = new AuditsRepository(iConnection);
        }

        [TestMethod]
        public void Execute()
        {
            Assert.IsTrue(Insert());
        }

        public bool Insert()
        {
            this.entidad = EntitiesCore.Audits()!;
            this.entidad = this.IRepository!.Insert(this.entidad!);
            return true;
        }
    }
}