using MainCore.Models;

namespace AspNetApi.Services.Interface
{
    public interface IVillageService
    {
        IEnumerable<Village> GetVillages(string world);

        IEnumerable<VillageDistance> GetVillages(string world, Coordinates coord);
    }
}