namespace Contentful.API.Configuration
{
    using System;
    using System.Configuration;
    public class BaseConfiguration
    {
        protected static object GetAppSetting(string key)
        {
            return GetAppSetting(key, typeof(string));
        }

        protected static object GetAppSetting(string key, Type expectedType)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            try
            {
                if (expectedType == typeof(int))
                    return int.Parse(value);
                if (expectedType == typeof(string))
                    return value;

                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Config key:{key} was expected to be of type {expectedType} but was not.", ex);
            }
        }
    }
}
