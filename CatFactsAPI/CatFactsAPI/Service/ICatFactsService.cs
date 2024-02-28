namespace CatFactsAPI.Service
{
    public interface ICatFactsService
    {
        Task<IEnumerable<CatFact>> GetCatFacts(string url);
    }
}
