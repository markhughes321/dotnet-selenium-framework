using dotenv.net;

namespace UITests.Helpers
{
    public static class TestConfig
    {
        static TestConfig()
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        }

        public static string RyanairEmail =>
            Environment.GetEnvironmentVariable("RYANAIR_EMAIL") ?? throw new Exception("RYANAIR_EMAIL not set");

        public static string RyanairPassword =>
            Environment.GetEnvironmentVariable("RYANAIR_PASSWORD") ?? throw new Exception("RYANAIR_PASSWORD not set");
    }
}
