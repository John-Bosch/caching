using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boschy.Caching.Tests
{
    [TestClass]
    public class CacheTests
    {
        // You could store each configuration item seperately in the cache. This gives
        // you better type control but is less efficient as each config item is loaded
        // individually as it times out or on initial load
        [TestMethod]
        public void TestMethod1()
        {
            ICacheProvider cache = new CacheProvider();

            var value1 = cache.GetItem("ConfigItem1", TimeSpan.FromMinutes(60), () =>
            {
                // This is where you go and get the value if it doesn't exist
                // in the cache
                return "Value1";
            });

            var value2 = cache.GetItem<int?>("ConfigItem2", TimeSpan.FromMinutes(60), () =>
            {
                // This is where you go and get the value if it doesn't exist
                // in the cache
                return 1;
            });
        }

        // You could store the whole configuration once as a dictionary. This potentiall requires
        // only one fetch to refresh the cache, but every value is an object and the caller would 
        // need to know how to convert it
        [TestMethod]
        public void TestMethod2()
        {
            ICacheProvider cache = new CacheProvider();

            var configuration = cache.GetItem("Configuration", TimeSpan.FromMinutes(60), () =>
            {
                // This is where you go and get the value if it doesn't exist
                // in the cache
                return new Dictionary<string, object>
                {
                    { "ConfigItem1", "ConfigValue1" },
                    { "ConfigItem2", 1 }
                };
            });

            var configurationValue = configuration["ConfigItem1"];
        }
    }
}
