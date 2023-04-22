using MainCore.Models;

namespace AspNetApi.Services.Interface
{
    public interface IPlayerService
    {
        IEnumerable<TravianObject> Get(string world);

        IEnumerable<Village> GetVillages(string world, int id);
    }
}