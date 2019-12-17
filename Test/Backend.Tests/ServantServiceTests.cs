using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ZetsubouGacha.Services;
using ZetsubouGacha.Settings;

namespace Backend.Tests
{
    [TestClass]
    public class ServantServiceTests
    {
        [TestMethod]
        public void
        AllServantsTest()
        {
            var settings = new DatabaseSettings()
            {
                ConnectionString = "mongodb://localhost:27017",
                Database = "ZetsubouTests",
                ServantsCollection = "Servants"
            };
            var servantService = new ServantService(settings);
            int limit = 69;
            var results = servantService.GetAllServantsAsync(limit).Result.ToList();
            Assert.AreEqual(results.Count, limit);
        }

        [TestMethod]
        public void
        ServantByIdTest()
        {
            int id = 69;
            var settings = new DatabaseSettings()
            {
                ConnectionString = "mongodb://localhost:27017",
                Database = "ZetsubouTests",
                ServantsCollection = "Servants"
            };
            var servantService = new ServantService(settings);
            var result = servantService.GetServantByIdAsync(id).Result;
            Assert.AreEqual(result.Id, 69);
        }
    }
}
