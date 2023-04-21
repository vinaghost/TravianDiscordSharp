using MainCore.Models;

namespace AspNetApi.Services.Interface
{
    public interface IWorldService
    {
        IEnumerable<World> GetWorlds();

        bool IsVaild(string world);
    }
}