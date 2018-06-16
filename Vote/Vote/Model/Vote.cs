using Newtonsoft.Json;

namespace Vote.Model
{
    public class Vote
    {
        [JsonIgnore] public Candidate Candidate { get; set; }

        [JsonProperty("vit")] public string Vit { get; set; }

        [JsonProperty("psi")] public string DistrictPsi { get; set; }

        [JsonProperty("timestamp")] public long Timestamp { get; set; }

        [JsonProperty("value")] public string CandidateName => $"{Candidate.Name} {Candidate.Surname}";
    }
}