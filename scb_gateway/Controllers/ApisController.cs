using lib_domain.Core;
using lib_repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using scb_gateway.Core;
using System;
using System.Collections.Generic;

namespace scb_gateway.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApisController : ControllerBase
    {
        private IApisRepository? IRepository = null;
        private IUsersRepository? IUsersRepository = null;

        public ApisController(IApisRepository iProductsRepository, 
            IUsersRepository iUsersRepository)
        {
            this.IRepository = iProductsRepository;
            this.IUsersRepository = iUsersRepository;

            var StringConexion = Configuration.Get("db.string_conexion")!;
            this.IRepository!.Configurar(StringConexion);
            this.IUsersRepository!.Configurar(StringConexion);
        }

        [HttpPost]
        public string Select()
        {
            var response = new Dictionary<string, object>();
            try
            {
                var data = ControllerHelper.GetData(Request);
                if (!((IUsersTokenRepository)this.IUsersRepository!)
                    .CheckCode(data["Authorization"].ToString(), Configuration.Get("app.secret")!))
                {
                    response["Error"] = "lbNoAutenticacion";
                    return JsonHelper.ConvertToString(response);
                }

                response["Entities"] = this.IRepository!.Select();

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