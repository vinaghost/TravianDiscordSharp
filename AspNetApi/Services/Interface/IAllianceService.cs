using MainCore.Models;

namespace AspNetApi.Services.Interface
{
    public interface IAllianceService
    {
        IEnumerable<TravianObject> GetAlliances(string world);
    }
}