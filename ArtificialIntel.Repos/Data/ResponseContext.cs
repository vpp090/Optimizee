using ArtificialIntel.Repos.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace ArtificialIntel.Repos.Data
{
    public class ResponseContext : IResponseContext
    {
        private readonly IConfiguration _configuration;
        public ResponseContext()
        {
           _configuration = new ConfigurationBuilder()
                 .SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .Build();

            var client = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);

            WorkspaceEntities = database.GetCollection<WorkspaceEntity>(_configuration["DatabaseSettings:CollectionName"]);
        }
        public IMongoCollection<WorkspaceEntity> WorkspaceEntities { get; set; }
    }
}
