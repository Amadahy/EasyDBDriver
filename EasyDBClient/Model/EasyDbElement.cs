using System.Text.Json.Serialization;

namespace EasyDBDriver.Model
{
    public class EasyDbElement
    {
        /// <summary>
        ///  used by database
        /// </summary>
        /// 
        [JsonPropertyName("_id")]
        public string Id { get; set; }
    }
}
