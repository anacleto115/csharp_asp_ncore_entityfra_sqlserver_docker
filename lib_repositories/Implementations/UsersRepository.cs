using lib_domain.Entities;
using lib_repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace lib_repositories.Implementations
{
    public class UsersRepository : IUsersRepository, IUsersTokenRepository
    {
        private IConnection? IConnection = null;
        private IAuditsRepository? IAuditsRepository = null;

        public UsersRepository(IConnection iConnection, IAuditsRepository iAuditsRepository)
        {
            this.IConnection = iConnection;
            this.IAuditsRepository = iAuditsRepository;
        }

        public void Configurar(string StringConexion)
        {
            this.IConnection!.StringConexion = StringConexion;
        }

        public List<Users> Select()
        {
            var list = this.IConnection!.Users!.Take(20).ToList();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Users.Select", description = "" });
            return list;
        }

        public List<Users> Where(Users entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            var list = this.IConnection!.Users!
                .Where(x => x.name == entity!.name &&
                            x.password == entity!.password &&
                            x.active)
                .ToList();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Users.Where", description = "" });
            return list;
        }

        public Users Insert(Users entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id != 0)
                throw new Exception("lbWasSaved");

            this.IConnection!.Users!.Add(entity);
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Users.Insert", description = entity.id.ToString() });
            return entity;
        }

        public Users Update(Users entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            var entry = this.IConnection!.Entry<Users>(entity);
            entry.State = EntityState.Modified;
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Users.Update", description = entity.id.ToString() });
            return entity;
        }

        public Users Delete(Users entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            this.IConnection!.Users!.Remove(entity);
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Users.Delete", description = entity.id.ToString() });
            return entity;
        }

        public string? CreateCode(Users entity, string? code)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, entity.name!)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(code!)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool CheckCode(string? data, string? code)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(data);
            if (DateTime.UtcNow > token.ValidTo)
                return false;

            string name = token.Claims.FirstOrDefault()!.Value!;
            return this.IConnection!.Users!
                .Where(x => x.name == name && x.active)
                .ToList().Count > 0;
        }

        private bool Validate(Users entity)
        {
            return entity == null ||
                string.IsNullOrEmpty(entity.name) ||
                string.IsNullOrEmpty(entity.password);
        }
    }
}