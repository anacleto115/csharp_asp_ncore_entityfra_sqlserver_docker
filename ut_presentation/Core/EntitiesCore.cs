using lib_domain.Entities;
using System;

namespace ut_presentation.Core
{
    public class EntitiesCore
    {
        public static Audits Audits()
        {
            Audits entity = new Audits();
            entity.action = "Unit.Tests";
            entity.description = "Pruebas-" + DateTime.Now.ToString();
            entity.date = DateTime.Now;
            return entity;
        }

        public static Users Users()
        {
            Users entity = new Users();
            entity.name = "Pruebas-" + DateTime.Now.ToString();
            entity.password = "KGgsdk3dsf464hfksdf";
            entity.active = true;
            return entity;
        }

        public static Types Types()
        {
            Types entity = new Types();
            entity.name = "Pruebas-" + DateTime.Now.ToString();
            return entity;
        }

        public static Products Products()
        {
            Products entity = new Products();
            entity.name = "Pruebas-" + DateTime.Now.ToString();
            entity.price = 5.0m;
            entity.expire = DateTime.Now;
            entity.type = 1;
            entity.active = true;
            entity.image = "654fgJHGjhdgdhfyi3432d1fg6sd7fg98BFjhdgfsdk5345";
            return entity;
        }
    }
}