using Microsoft.Extensions.Configuration;

namespace DemoQA_Automation.Helpers
{
    public static class Configuration
    {
        private static IConfiguration? _config;

        public static IConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new ConfigurationBuilder()
                        .SetBasePath(TestContext.CurrentContext.TestDirectory)
                        .AddJsonFile("appsettings.json", optional: false)
                        .Build();
                }
                return _config;
            }
        }
    }
}
