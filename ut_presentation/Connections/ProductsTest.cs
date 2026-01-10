using lib_domain.Entities;
using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using ut_presentation.Core;
using System.Linq;
using System.Collections.Generic;

namespace ut_presentation.Connections
{
    [TestClass]
    public class ProductsTest
    {
        private readonly IConnection? iConnection;
        private List<Products>? list;
        private Products? entidad;

        public ProductsTest()
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
            this.entidad = EntitiesCore.Products()!;
            this.iConnection!.Products!.Add(this.entidad);
            this.iConnection!.SaveChanges();
            return true;
        }

        public bool Select()
        {
            this.list = this.iConnection!.Products!.ToList();
            return list.Count > 0;
        }

        public bool Update()
        {
            this.entidad!.active = false;
            var entry = this.iConnection!.Entry<Products>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConnection!.SaveChanges();
            return true;
        }

        public bool Delete()
        {
            this.iConnection!.Products!.Remove(this.entidad!);
            this.iConnection!.SaveChanges();
            return true;
        }
    }
}