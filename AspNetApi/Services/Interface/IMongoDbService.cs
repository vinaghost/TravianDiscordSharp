using MainCore.Models;
using MongoDB.Driver;

namespace AspNetApi.Services.Interface
{
    public interface IMongoDbService
    {
        public IMongoCollection<World> GetWorlds();

        public IMongoCollection<Village> GetVillages(string world);
    }
}