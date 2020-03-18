using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using MongoDB.Driver;
using ZetsubouGacha.Servants.Models;
using ZetsubouGacha.Servants.Controllers;
using ZetsubouGacha.Databases;

namespace ZetsubouGacha.Tests
{
    [TestClass]
    public class ServantControllerTest
    {
        [TestMethod]
        public void ServantById()
        {
            var mockRepo = new Mock<IServantRepository>();
            var mockDbContext = new Mock<IDbContext>();

            var servant = new Servant()
            {
                Id = 1,
                Name = "MockedServant",
                Title = "MockServantTitle",
                FirstAscensionImage = "MockFirstAscImage",
                FinalAscensionImage = "MockFinalAscImage",
                Dialogue = "MockDialogue",
                Audio = "MockAudio"
            };

            mockRepo.Setup(repo => repo.GetServantByIdAsync(1)).ReturnsAsync(servant);
            mockDbContext.Setup(db => db.Servants).Returns(mockRepo.Object);

            var sut = new ServantController(mockDbContext.Object);
            var result = sut.ServantById(1).Result.Value;
            Assert.AreEqual(servant.Id, result.Id);
            Assert.AreEqual(servant.Title, result.Title);
            Assert.AreEqual(servant.FinalAscensionImage, result.FinalAscensionImage);
        }

        [TestMethod]
        public void AllServants()
        {
            var mockRepo = new Mock<IServantRepository>();
            var mockDbContext = new Mock<IDbContext>();

            var servant = new Servant()
            {
                Id = 1,
                Name = "MockedServant",
                Title = "MockServantTitle",
                FirstAscensionImage = "MockFirstAscImage",
                FinalAscensionImage = "MockFinalAscImage",
                Dialogue = "MockDialogue",
                Audio = "MockAudio"
            };

            int limit = 100;
            mockRepo.Setup(repo => repo.GetAllServantsAsync(limit)).ReturnsAsync(Enumerable.Range(1, limit).Select(_ => servant));
            mockDbContext.Setup(db => db.Servants).Returns(mockRepo.Object);

            var sut = new ServantController(mockDbContext.Object);
            var result = sut.AllServants(limit).Result.Value;
            Assert.AreEqual(limit, result.Count());
        }
    }
}
