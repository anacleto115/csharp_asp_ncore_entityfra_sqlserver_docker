using lib_domain.Entities;
using lib_repositories.Implementations;
using lib_repositories.Interfaces;
using System.Collections.Generic;
using ut_presentation.Core;

namespace ut_presentation.Repositories
{
    [TestClass]
    public class ProductsTest
    {
        private readonly IProductsRepository? IRepository;
        private List<Products>? list;
        private Products? entidad;

        public ProductsTest()
        {
            var iConnection = new Connection();
            iConnection.StringConexion = Configuration.Get("StringConexion");
            
            IRepository = new ProductsRepository(iConnection, 
                new AuditsRepository(iConnection));
        }

        [TestMethod]
        public void Execute()
        {
            Assert.IsTrue(Insert());
            Assert.IsTrue(Update());
            Assert.IsTrue(Select());
            Assert.IsTrue(Where());
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
            this.entidad = EntitiesCore.Products()!;
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