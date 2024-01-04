using ArtificialIntel.Repos.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace ArtificialIntel.Repos.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;
        public CatalogContext()
        {
           _configuration = new ConfigurationBuilder()
                 .SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .Build();

            var client = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);

            WorkspaceEntities = database.GetCollection<WorskpaceEntity>(_configuration["DatabaseSettings:CollectionName"]);
        }
        public IMongoCollection<WorskpaceEntity> WorkspaceEntities { get; set; }
    }
}
