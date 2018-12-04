using Microsoft.Extensions.Configuration;
using System;

namespace HT.Framework.Common
{
    public static class ConfigHelper
    {
        private static IConfigurationSection _appSection = null;
        public static string AppSetting(string key)
        {
            var str = "";
            if (_appSection.GetSection(key) != null)
            {
                str = _appSection.GetSection(key).Value;
            }
            return str;
        }

        public static void SetAppSetting(IConfigurationSection section)
        {
            _appSection = section;
        }

        public static string GetSite(string apiName)
        {
            return AppSetting(apiName);
        }
    }
}
