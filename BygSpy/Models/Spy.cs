using System.Text.Json.Serialization;

namespace BygSpy.Models
{
    public class Spy
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

    }
}
