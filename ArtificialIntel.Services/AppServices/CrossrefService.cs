using ArtificialIntel.Services.Contracts;
using Microsoft.Extensions.Configuration;

namespace ArtificialIntel.Services.AppServices
{
    public class CrossrefService : ICrossrefService
    {
        private IConfiguration _configuration;

        public CrossrefService(IHttpClientFactory factory, IConfiguration config)
        {
            _configuration = config;
        }
        public async Task<IEnumerable<string>> SendRequestToCrossref(List<string> subTopics, 
                                                            int rows,
                                                            int offset, 
                                                            IHttpClientFactory factory)
        {
            var result = new List<string>();

            var apiUrl = _configuration["Crossref:ApiUrl"].ToString();
            
            foreach(var topic in subTopics)
            {
                var client = factory.CreateClient();

                var fullUrl = apiUrl + $"works?rows={rows}&offset={offset}&query={topic}";
                var response = await client.GetAsync(fullUrl);

                result.Add(await response.Content.ReadAsStringAsync());
            }

            return result;
        }
    }
}
