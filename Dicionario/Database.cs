using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dicionario
{
    internal class Database
    {   
        
        public static string FILE_PATH = Path.Join(Environment.CurrentDirectory, "..", "..", "..", "database", "dicionario.json");

        public static List<string> loadJson()
        {
            using (StreamReader r = new StreamReader(FILE_PATH))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
        }

        public static void saveJson(List<string> _data)
        {
            string json = JsonConvert.SerializeObject(_data, Formatting.Indented);
            File.WriteAllText(FILE_PATH, json);
        }
    }
}
