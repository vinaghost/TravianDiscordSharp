using MainCore.Models;

namespace AspNetApi.Services.Interface
{
    public interface IPlayerService
    {
        IEnumerable<TravianObject> GetPlayers(string world);

        IEnumerable<Village> GetVillages(string world, int id);
    }
}