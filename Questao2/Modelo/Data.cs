using System.Text.Json.Serialization;

namespace Questao2.Modelo
{
    public class Data
    {
        [JsonPropertyName("competition")]
        public string? Competition { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }

        [JsonPropertyName("round")]
        public string? Round { get; set; }

        [JsonPropertyName("team1")]
        public string? Team1 { get; set; }

        [JsonPropertyName("team2")]
        public string? Team2 { get; set; }

        [JsonPropertyName("team1goals")]
        public string? Team1goals { get; set; }

        [JsonPropertyName("team2goals")]
        public string? Team2goals { get; set; }
    }
}
