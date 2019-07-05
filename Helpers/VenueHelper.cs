using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiveMusicFinder.Helpers
{
    public static class VenueHelper
    {
        public static async Task<IEnumerable<string>> GetVenuesAsync()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("x-api-key", "6dgJUQD8JSb-TvbOH4jkI_6uga6KrgydMGp7");
            var response = await client.GetStringAsync("https://api.setlist.fm/rest/1.0/search/venues?cityName=Vienna&country=AT&p=1");
            var json = JObject.Parse(response);
            var venues = json["venue"].Select(v => v["name"].ToString());
            return venues;
        }
    }
}
