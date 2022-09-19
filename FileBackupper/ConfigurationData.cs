using Newtonsoft.Json;
using System.IO;

namespace FileBackupper
{
    public class ConfigurationData
    {
        [JsonProperty("OriginPath")]
        public string OriginPath { get; set; }

        [JsonProperty("TargetPath")]
        public string TargetPath { get; set; }

        public static ConfigurationData GetDataFromJson(string configData)
        {
            
            string configDataString = File.ReadAllText(configData);
            return JsonConvert.DeserializeObject<ConfigurationData>(configDataString);
           
        }
    }
}
