using System.Net.Http;
using System.Text.Json;

namespace CatFactsAPI.Service
{
    public class CatFactsService: ICatFactsService
    {
        private readonly HttpClient httpClient;
        public CatFactsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CatFact>> GetCatFacts(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("public api url is incorrect");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var serializedCatFacts = JsonSerializer.Deserialize<IEnumerable<CatFact>>(responseBody);
            
            if (serializedCatFacts == null) throw new Exception("Can not get cat facts");
            return serializedCatFacts;
        }
    }
}
