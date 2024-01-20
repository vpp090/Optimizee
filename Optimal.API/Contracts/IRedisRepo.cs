using App.Domain.Entities;

namespace Optimal.API.Contracts
{
    public interface IRedisRepo
    {
        Task<string> GetDataFromRedisAsync(string key);
        //Task<IEnumerable<Author>> GetAuthorsAsync(string key);
        //Task<IEnumerable<Material>> GetMaterialsAsync(string key);
    }
}
