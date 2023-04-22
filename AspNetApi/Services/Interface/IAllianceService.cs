using MainCore.Models;

namespace AspNetApi.Services.Interface
{
    public interface IAllianceService
    {
        IEnumerable<TravianObject> Get(string world);

        IEnumerable<Village> GetVillages(string world, int id);
    }
}