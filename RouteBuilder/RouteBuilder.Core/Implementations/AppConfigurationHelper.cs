using System.Configuration;

namespace RouteBuilder.Core.Implementations
{
    internal static class AppConfigurationHelper
    {
        public static string GetHost()
        {
            return GetStringSetting("Host");
        }
        public static string GetAirlineEndpoint()
        {
            return GetStringSetting("AirlineEndpoint");
        }

        public static string GetRouteEndpoint()
        {
            return GetStringSetting("RouteEndpoint");
        }

        public static string GetAirportEndpoint()
        {
            return GetStringSetting("AirportEndpoint");
        }

        private static string GetStringSetting(string key)
        {
            return ReadSetting(key);
        }

        private static string ReadSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }
    }
}