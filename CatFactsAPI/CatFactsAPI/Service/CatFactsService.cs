using System.Text.Json;

namespace CatFactsAPI.Service
{
    public class CatFactsService: ICatFactsService
    {
        public async Task<IEnumerable<CatFact>> GetCatFacts(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var serializedCatFacts = JsonSerializer.Deserialize<IEnumerable<CatFact>>(responseBody);
            
            if (serializedCatFacts == null) throw new Exception("Can not get cat facts");
            return serializedCatFacts;
        }
    }
}
