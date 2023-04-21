namespace MainCore.Helper
{
    public static class EnvVarHelper
    {
        public static string MogoDbConnection { get; } = Environment.GetEnvironmentVariable("MONGODB_URI");
    }
}