using lib_domain.Core;
using lib_domain.Entities;
using lib_repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using scb_services.Core;
using System;
using System.Collections.Generic;

namespace scb_services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TypesController : ControllerBase
    {
        private ITypesRepository? IRepository = null;
        private IUsersRepository? IUsersRepository = null;

        public TypesController(ITypesRepository iTypesRepository, 
            IUsersRepository iUsersRepository)
        {
            this.IRepository = iTypesRepository;
            this.IUsersRepository = iUsersRepository;

            var StringConexion = Configuration.Get("db.string_conexion")!;
            this.IRepository!.Configurar(StringConexion);
            this.IUsersRepository!.Configurar(StringConexion);
        }

        [HttpGet]
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

        [HttpPost]
        public string Where()
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

                var entity = JsonHelper.ConvertToObject<Types>(
                    JsonHelper.ConvertToString(data["Entity"]));

                response["Entities"] = this.IRepository!.Where(entity);

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
        public string Insert()
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

                var entity = JsonHelper.ConvertToObject<Types>(
                    JsonHelper.ConvertToString(data["Entity"]));
                response["Entity"] = this.IRepository!.Insert(entity);

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

        [HttpPut]
        public string Update()
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

                var entity = JsonHelper.ConvertToObject<Types>(
                    JsonHelper.ConvertToString(data["Entity"]));
                response["Entity"] = this.IRepository!.Update(entity);

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

        [HttpDelete]
        public string Delete()
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

                var entity = JsonHelper.ConvertToObject<Types>(
                    JsonHelper.ConvertToString(data["Entity"]));
                response["Entity"] = this.IRepository!.Delete(entity);

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