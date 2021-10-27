using System.Text.Json.Serialization;

namespace EasyDBDriver.Model
{
    public class FileModel
    {
        [JsonPropertyName("id")]
        public string Id {get; set;}
        [JsonPropertyName("type")]
        public string Type { get; set; } = "EASY_DB_FILE";
        [JsonPropertyName("url")]
        public string Url { get; set; } 
    }
}
