using ServiceStack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KingmanAzFrcTeam60.Data
{

    public class SponsorYears
    {
        [JsonPropertyName("Years")]
        public SponsorYear[]? Years { get; set; }
    }

    public class SponsorYear
    {
        [JsonPropertyName("year")] 
        public string? Year { get; set; }

        [JsonPropertyName("sponsors")]
        public Sponsor[]? Sponsors { get; set; }
    }

    public class Sponsor
    {
        [JsonPropertyName("businessName")]
        public string? BusinessName { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }
    }

    public class SponorsSource
    {
        public SponsorYears? Sponsors = null;
        public async Task PopulateSponsors(HttpClient client)
        {
            try
            {
                Sponsors = await client.GetFromJsonAsync<SponsorYears>("/OurSponsors");
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}
