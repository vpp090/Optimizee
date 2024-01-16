namespace ArtificialIntel.Services.Contracts
{
    public interface ICrossrefService
    {
        Task<IEnumerable<string>> SendRequestToCrossref(List<string> subTopics, int rows, int offset, IHttpClientFactory factory);
    }
}
