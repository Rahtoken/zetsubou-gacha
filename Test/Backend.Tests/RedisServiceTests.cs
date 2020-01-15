using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZetsubouGacha.Models;
using ZetsubouGacha.Services;
using ZetsubouGacha.Settings;

namespace Backend.Tests
{
    [TestClass]
    public class RedisServiceTests
    {
        [TestMethod]
        public void SerializationTest()
        {
            var item = GetServant();
            var serialized = RedisService.Serialize<Servant>(item);
            var deserialized = RedisService.Deserialize<Servant>(serialized);
            Assert.AreEqual(item.Id, deserialized.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(StackExchange.Redis.RedisConnectionException))]
        public void ConnectionFailTest()
        {
            var settings = new RedisSettings()
            {
                Host = "localhost",
                Port = "6969"
            };
            var redis = new RedisService(settings);
            redis.Connect();
            Assert.Fail("The connection should've failed.");
        }

        [TestMethod]
        public void DataAccessTest()
        {
            var settings = new RedisSettings()
            {
                Host = "localhost",
                Port = "6379"
            };
            var redis = new RedisService(settings);
            redis.Connect();
            var item = GetServant();
            var value = RedisService.Serialize<Servant>(item);
            redis.PutAsync(item.Id.ToString(), value).Wait();
            var retrieved = redis.GetAsync(item.Id.ToString()).Result;
            Assert.AreEqual(retrieved.success, true);
            var retrievedItem = RedisService.Deserialize<Servant>(retrieved.result);
            Assert.AreEqual(retrievedItem.Dialogue, item.Dialogue);
        }

        public static Servant GetServant()
        {
            return new Servant()
            {
                Id = 1,
                Name = "TestServant",
                Title = "TestTitle",
                Dialogue = "It's me, Dio!",
                FirstAscensionImage = "https://www.google.com/",
                FinalAscensionImage = "https://www.google.com/",
                Audio = "Meow",
            };
        }
    }
}
