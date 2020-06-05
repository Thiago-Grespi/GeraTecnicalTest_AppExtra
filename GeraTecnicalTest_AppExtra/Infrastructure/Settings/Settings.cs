using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Json;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class Settings
    {
        public static bool CLOSE_BROWSER_AFTER_SCENARIO { get; set; }
        public static bool CLOSE_BROWSER_AFTER_ALL_SCENARIO { get; set; }
        public static int SECONDS_TO_WAIT { get; set; }
        public static string EXECUTION_PATH
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }
        public static Enums.Browsers BROWSER { get; set; }

        /// <summary>
        /// Pegar as configurações de um arquivo JSON e armazena em atributos estáticos
        /// </summary>
        public static void GetConfig()
        {
            string json = File.ReadAllText(EXECUTION_PATH + @"\Settings\appSettings.json");

            JsonObject jsonConfigurations = JsonConvert.DeserializeObject<JsonObject>(json);

            CLOSE_BROWSER_AFTER_SCENARIO = jsonConfigurations["CLOSE_BROWSER_AFTER_TEST"];
            CLOSE_BROWSER_AFTER_ALL_SCENARIO = jsonConfigurations["CLOSE_BROWSER_AFTER_ALL_TESTS"];
            SECONDS_TO_WAIT = jsonConfigurations["SECONDS_TO_WAIT"];
            BROWSER = (Enums.Browsers)(int)jsonConfigurations["BROWSER"];
        }
    }
}
