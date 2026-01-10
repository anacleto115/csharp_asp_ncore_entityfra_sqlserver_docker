using lib_domain.Entities;
using lib_repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lib_repositories.Implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private IConnection? IConnection = null;
        private IAuditsRepository? IAuditsRepository = null;

        public ProductsRepository(IConnection iConnection, IAuditsRepository iAuditsRepository)
        {
            this.IConnection = iConnection;
            this.IAuditsRepository = iAuditsRepository;
        }

        public void Configurar(string StringConexion)
        {
            this.IConnection!.StringConexion = StringConexion;
        }

        public List<Products> Select()
        {
            var list = this.IConnection!.Products!
                .Take(200)
                .Include(x => x._type)
                .ToList();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Products.Select", description = "" });
            return list;
        }

        public List<Products> Where(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            var list = this.IConnection!.Products!
                .Where(x => x.name!.Contains(entity!.name!))
                .Take(200)
                .Include(x => x._type)
                .ToList();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Products.Where", description = entity.id.ToString() });
            return list;
        }

        public Products Insert(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id != 0)
                throw new Exception("lbWasSaved");

            this.IConnection!.Products!.Add(entity);
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Products.Insert", description = entity.id.ToString() });
            return entity;
        }

        public Products Update(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            var entry = this.IConnection!.Entry<Products>(entity);
            entry.State = EntityState.Modified;
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Products.Update", description = entity.id.ToString() });
            return entity;
        }

        public Products Delete(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            this.IConnection!.Products!.Remove(entity);
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Products.Delete", description = "" });
            return entity;
        }

        private bool Validate(Products entity)
        {
            return entity == null ||
                string.IsNullOrEmpty(entity.name) ||
                entity.expire == null;
        }
    }
}