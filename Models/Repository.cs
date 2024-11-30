using System.Text.Json.Serialization;

namespace web_api.Models
{
    internal class Repository
    {
        // maps to the "name" field in the JSON response
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // maps to the "homepage" field in the JSON response
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        // maps to the "html_url" field in the JSON response
        [JsonPropertyName("html_url")]
        public string GitHub { get; set; }

        // maps to the "description" field in the JSON response
        [JsonPropertyName("description")]
        public string Description { get; set; }

        // maps to the "watchers_count" field in the JSON response
        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        // maps to the "updated_at" field in the JSON response
        [JsonPropertyName("updated_at")]
        public DateTime? LastPush { get; set; }


    }
}
