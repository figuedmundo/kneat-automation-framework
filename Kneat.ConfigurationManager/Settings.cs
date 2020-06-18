using System.IO;
using Microsoft.Extensions.Configuration;

namespace Kneat.ConfigurationManager
{
    public class Settings
    {
        private static IConfiguration _config;
        public static IConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                    _config = builder.Build();
                }

                return _config;
            }
        }
    }
}
