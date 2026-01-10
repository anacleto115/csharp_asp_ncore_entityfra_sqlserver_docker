using lib_domain.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace scb_gateway.Core
{
    public class Configuration
    {
        private static Dictionary<string, string>? data;

        public static string? Get(string key)
        {
            return Service(key);
            //return Local(key);
        }

        private static string? Service(string key)
        {
            return Startup.Configuration!.GetSection(key).Value! ??
                Startup.Configuration!.GetSection("Settings").GetSection(key).Value! ??
                Startup.Configuration!.GetConnectionString(key)!;
        }

        private static string Local(string key)
        {
            if (data == null)
                Load();
            return data![key].ToString();
        }

        private static void Load()
        {
            var path3 = GetPath() + @"\config.json";
            if (!File.Exists(path3))
                return;
            data = new Dictionary<string, string>();
            StreamReader jsonStream = File.OpenText(path3);
            var json = jsonStream.ReadToEnd();
            data = JsonHelper.ConvertToObject<Dictionary<string, string>>(json)!;
        }

        private static string? GetPath()
        {
            var response = Environment.CurrentDirectory;
            for (var count = 0; count < 1; count++)
                response = Path.GetDirectoryName(response);
            return response;
        }
    }
}