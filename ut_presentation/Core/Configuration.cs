using lib_domain.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace ut_presentation.Core
{
    public class Configuration
    {
        private static Dictionary<string, string>? data = null;

        public static string Get(string key)
        {
            if (data == null)
                Load();
            return data![key].ToString();
        }

        public static void Load()
        {
            var path3 = GetPath() + @"\config.json";
            if (!File.Exists(path3))
                return;
            data = new Dictionary<string, string>();
            StreamReader jsonStream = File.OpenText(path3);
            var json = jsonStream.ReadToEnd();
            data = JsonHelper.ConvertToObject<Dictionary<string, string>>(json)!;
        }

        public static string? GetPath()
        {
            var response = Environment.CurrentDirectory;
            for (var count = 0; count < 4; count++)
                response = Path.GetDirectoryName(response);
            return response;
        }
    }
}