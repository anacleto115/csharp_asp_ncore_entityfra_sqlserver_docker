using lib_domain.Core;
using lib_domain.Entities;
using lib_repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using scb_gateway.Core;
using System;
using System.Collections.Generic;

namespace scb_gateway.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        private IUsersRepository? IRepository = null;

        public TokenController(IUsersRepository iUsersRepository)
        {
            this.IRepository = iUsersRepository;

            var StringConexion = Configuration.Get("db.string_conexion")!;
            this.IRepository!.Configurar(StringConexion);
        }

        [HttpPost]
        public string Version()
        {
            var response = new Dictionary<string, object>();
            try
            {
                var data = ControllerHelper.GetData(Request);
                if (!((IUsersTokenRepository)this.IRepository!)
                    .CheckCode(data["Authorization"].ToString(), Configuration.Get("app.secret")!))
                {
                    response["Error"] = "lbNoAutenticacion";
                    return JsonHelper.ConvertToString(response);
                }

                response["Version"] = Configuration.Get("app.version")!;
                response["Response"] = "OK";
                response["Date"] = DateTime.Now.ToString();
                return JsonHelper.ConvertToString(response);
            }
            catch (Exception ex)
            {
                response["Error"] = ex.Message.ToString();
                return JsonHelper.ConvertToString(response);
            }
        }

        [HttpPost]
        public string Authenticate()
        {
            var response = new Dictionary<string, object>();
            try
            {
                var data = ControllerHelper.GetData(Request); 
                
                this.IRepository!.Configurar(Configuration.Get("db.string_conexion")!);
                var entity = JsonHelper.ConvertToObject<Users>(
                    JsonHelper.ConvertToString(data["Entity"]));

                var list = this.IRepository!.Where(entity);
                if (list.Count <= 0)
                {
                    response["Error"] = "lbNoAutenticacion";
                    return JsonHelper.ConvertToString(response);
                }

                response["Token"] = ((IUsersTokenRepository)this.IRepository!)
                    .CreateCode(entity, Configuration.Get("app.secret")!)!;
                response["Response"] = "OK";
                response["Date"] = DateTime.Now.ToString();
                return JsonHelper.ConvertToString(response);
            }
            catch (Exception ex)
            {
                response["Error"] = ex.Message.ToString();
                return JsonHelper.ConvertToString(response);
            }
        }
    }
}