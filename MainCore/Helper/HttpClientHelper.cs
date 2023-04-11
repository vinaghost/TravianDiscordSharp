namespace MainCore.Helper
{
    public static class HttpClientHelper
    {
        private static HttpClient _httpClient;

        public static HttpClient GetClient()
        {
            if (_httpClient is null)
            {
                var socketsHandler = new SocketsHttpHandler
                {
                    PooledConnectionLifetime = TimeSpan.FromSeconds(60),
                    PooledConnectionIdleTimeout = TimeSpan.FromMinutes(20),
                    MaxConnectionsPerServer = 10
                };
                _httpClient = new HttpClient(socketsHandler);
            }
            return _httpClient;
        }

        public static void Dispose() => _httpClient?.Dispose();
    }
}