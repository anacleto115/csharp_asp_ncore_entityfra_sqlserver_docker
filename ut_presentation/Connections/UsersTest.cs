using lib_domain.Entities;
using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using ut_presentation.Core;
using System.Collections.Generic;
using System.Linq;

namespace ut_presentation.Connections
{
    [TestClass]
    public class UsersTest
    {
        private readonly IConnection? iConnection;
        private List<Users>? list;
        private Users? entidad;

        public UsersTest()
        {
            iConnection = new Connection();
            iConnection.StringConexion = Configuration.Get("StringConexion");
        }

        [TestMethod]
        public void Execute()
        {
            Assert.IsTrue(Insert());
            Assert.IsTrue(Update());
            Assert.IsTrue(Select());
            Assert.IsTrue(Delete());
        }

        public bool Insert()
        {
            this.entidad = EntitiesCore.Users()!;
            this.iConnection!.Users!.Add(this.entidad);
            this.iConnection!.SaveChanges();
            return true;
        }

        public bool Select()
        {
            this.list = this.iConnection!.Users!.ToList();
            return list.Count > 0;
        }

        public bool Update()
        {
            this.entidad!.active = false;
            var entry = this.iConnection!.Entry<Users>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConnection!.SaveChanges();
            return true;
        }

        public bool Delete()
        {
            this.iConnection!.Users!.Remove(this.entidad!);
            this.iConnection!.SaveChanges();
            return true;
        }
    }
}