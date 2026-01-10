using lib_domain.Core;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace scb_gateway.Controllers
{
    public class ControllerHelper
    {
        public static Dictionary<string, object> GetData(HttpRequest Request)
        {
            var data = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(data))
                data = "{}";
            var response = JsonHelper.ConvertToObject(data);
            response["Authorization"] = Request.Headers["Authorization"].ToString();
            return response;
        }
    }
}