using System.Text.Json;
using System.Text.Json.Serialization;

namespace KingmanAzFrcTeam60.Data
{
    public class Link
    {
        public Link(string name, string url)
        {
            Name = name;
            Url = url;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public string HRef
        {
            get
            {
                var str = String.Format("<a href=\"{0}\">{0}</a>", Url);
                return str;
            }
        }
    }

    public class LinksSource
    {
        public Link[]? Links { get; set; }

        public async Task PopulateLinks()
        {
            try
            {
                var localDir = System.IO.Directory.GetCurrentDirectory();
                var path = Path.Combine(localDir, "wwwroot", "Links.json");
                var linksFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                Links = await JsonSerializer.DeserializeAsync<Link[]>(linksFile);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}
