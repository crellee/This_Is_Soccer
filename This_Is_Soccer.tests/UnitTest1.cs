using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using This_Is_Soccer.Models.Interface;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;
using This_Is_Soccer.Controllers;

namespace This_Is_Soccer.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            //Arrange
            var MockIPlayerRepo = new Mock<IPlayerRepository>();
            var MockIGenericRepo = new Mock<IGenericRepository<PlayerModel>>();
            PlayerController controller = new PlayerController(MockIPlayerRepo.Object, MockIGenericRepo.Object);
            PlayerModel player = new PlayerModel()
            {
                PlayerId = 2,
                PlayerName = "Chris",
                PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/193041.png",
                ClubId = 2,
                PositionId = 1
            };

            //Act
            controller.Create(player);

            //Assert
            MockIGenericRepo.Verify(r => r.Insert(player));
            

        }
    }
}
