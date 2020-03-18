using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZetsubouGacha.Databases;
using ZetsubouGacha.Servants.Controllers;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Tests
{
    [TestClass]
    public class ServantControllerTest
    {
        [TestMethod]
        public void ServantByIdSuccess()
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
        public void ServantByIdFail()
        {
            var mockRepo = new Mock<IServantRepository>();
            var mockDbContext = new Mock<IDbContext>();

            Servant servant = null;

            mockRepo.Setup(repo => repo.GetServantByIdAsync(-1)).ReturnsAsync(servant);
            mockDbContext.Setup(db => db.Servants).Returns(mockRepo.Object);

            var sut = new ServantController(mockDbContext.Object);
            var result = sut.ServantById(-1).Result.Value;
            Assert.IsNull(result);
        }
    }
}