using lib_domain.Entities;
using lib_repositories.Implementations;
using lib_repositories.Interfaces;
using System.Collections.Generic;
using ut_presentation.Core;

namespace ut_presentation.Repositories
{
    [TestClass]
    public class UsersTest
    {
        private readonly IUsersRepository? IRepository;
        private List<Users>? list;
        private Users? entidad;

        public UsersTest()
        {
            var iConnection = new Connection();
            iConnection.StringConexion = Configuration.Get("StringConexion");

            IRepository = new UsersRepository(iConnection,
                new AuditsRepository(iConnection));
        }

        [TestMethod]
        public void Execute()
        {
            Assert.IsTrue(Insert());
            Assert.IsTrue(Where());
            Assert.IsTrue(Update());
            Assert.IsTrue(Select());
            Assert.IsTrue(Delete());
        }

        public bool Select()
        {
            this.list = this.IRepository!.Select();
            return list.Count > 0;
        }

        public bool Where()
        {
            this.list = this.IRepository!.Where(this.entidad!);
            return list.Count > 0;
        }

        public bool Insert()
        {
            this.entidad = EntitiesCore.Users()!;
            this.entidad = this.IRepository!.Insert(this.entidad!);
            return true;
        }

        public bool Update()
        {
            this.entidad!.active = false;
            this.entidad = this.IRepository!.Update(this.entidad!);
            return true;
        }

        public bool Delete()
        {
            this.entidad = this.IRepository!.Delete(this.entidad!);
            return true;
        }
    }
}