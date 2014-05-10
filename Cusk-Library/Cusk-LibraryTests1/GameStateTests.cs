using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cusk_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace Cusk_Library.Tests
{
    [TestClass()]
    public class GameStateTests
    {
        private GameStateAndChecker CreateMockGameState(bool GoodGameState = true)
        {
            var gameStateMock = new Mock<IGameState>();
            if (GoodGameState)
                gameStateMock.Setup(m => m.Serialize()).Returns(new object());
            else
                gameStateMock.Setup(m => m.Serialize()).Throws(new Exception());

            var gameStateCheckerMock = new Mock<IGameStateChecker>();
            return new GameStateAndChecker() { gameState = gameStateMock.Object, gameStateChecker = gameStateCheckerMock.Object };
        }

        [TestMethod()]
        public void GameStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeTest()
        {
            Assert.Fail();
        }
    }
}
