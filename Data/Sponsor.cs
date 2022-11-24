using ServiceStack;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KingmanAzFrcTeam60.Data
{
    public class SponsorsList
    {
        [JsonPropertyName("sponsors")]
        public Sponsor[]? Sponsors;
    }

    public class Sponsor
    {
        [JsonPropertyName("businessName")]
        public string? BusinessName { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonPropertyName("years")]
        public int[]? Years { get; set; }

        public string AllYears => Years.Join(",");

        public string GetWebsite => Website == null ? "" : Website == "null" ? "" : Website;

    }


    public class SponorsSource
    {
        public Sponsor[]? Sponsors = null;
        public async Task PopulateSponsors(HttpClient client)
        {
            try
            {
                var localDir = System.IO.Directory.GetCurrentDirectory();
                //Sponsors = await client.GetFromJsonAsync<Sponsor[]>("/OurSponsors");
                var path = Path.Combine(localDir, "wwwroot", "Sponsors2.json");
                var sponsorsFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                Sponsors = await JsonSerializer.DeserializeAsync<Sponsor[]>(sponsorsFile);
                if (Sponsors != null)
                {
                    Array.Sort(Sponsors, (lh, rh) => String.Compare(lh.BusinessName, rh.BusinessName));
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}
