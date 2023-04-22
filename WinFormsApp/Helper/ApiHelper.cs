using MainCore.Models;
using System.Net.Http.Json;

namespace WinFormsApp.Helper
{
    public class ApiHelper
    {
        private static readonly string _baseUrl = "http://168.138.187.133:5000";
        private static HttpClient _httpClient;

        public static void InitHttpClient()
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromSeconds(60),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(20),
                MaxConnectionsPerServer = 10
            };
            _httpClient = new HttpClient(socketsHandler);
        }

        public static void Dispose() => _httpClient?.Dispose();

        public static async Task<List<World>> GetWorlds()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/world/");
            var content = await response.Content.ReadFromJsonAsync<List<World>>();
            return content;
        }

        public static async Task<List<Village>> GetVillages(string world)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/village/{world}");
            var content = await response.Content.ReadFromJsonAsync<List<Village>>();
            return content;
        }

        public static async Task<List<TravianObject>> GetAlliances(string world)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/alliance/{world}");
            var content = await response.Content.ReadFromJsonAsync<List<TravianObject>>();
            return content;
        }

        public static async Task<List<TravianObject>> GetPlayers(string world)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/player/{world}");
            var content = await response.Content.ReadFromJsonAsync<List<TravianObject>>();
            return content;
        }

        public static async Task<List<Village>> GetPlayerVillages(string world, int index)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/player/{world}/{index}");
            var content = await response.Content.ReadFromJsonAsync<List<Village>>();
            return content;
        }

        public static async Task<List<VillageDistance>> GetDistanceVillages(string world, int x, int y)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/village/{world}/distance?x={x}&y={y}");
            var content = await response.Content.ReadFromJsonAsync<List<VillageDistance>>();
            return content;
        }
    }
}