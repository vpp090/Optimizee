using ArtificialIntel.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace ArtificialIntel.Repos.Data
{
    public class ResponseContext : IResponseContext
    {
        private readonly IConfiguration _configuration;
        public ResponseContext()
        {
            var dir = AppContext.BaseDirectory;

           _configuration = new ConfigurationBuilder()
                 .SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                 .Build();

            var client = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);

            WorkspaceEntities = database.GetCollection<WorkspaceEntity>(_configuration["DatabaseSettings:CollectionName"]);

            ResponseContextSeeder.SeedData(WorkspaceEntities);
        }
        public IMongoCollection<WorkspaceEntity> WorkspaceEntities { get; set; }
    }
}
