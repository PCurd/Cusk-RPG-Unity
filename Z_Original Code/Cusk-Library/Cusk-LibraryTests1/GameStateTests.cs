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
                gameStateMock.Setup(m => m.Serialize()).Returns("something");
            else
                gameStateMock.Setup(m => m.Serialize()).Throws(new Exception());

            var gameStateCheckerMock = new Mock<IGameStateChecker>();
            gameStateCheckerMock.Setup(m => m.Check(It.IsAny<IGameState>())).Returns(GoodGameState);

            return new GameStateAndChecker() { gameState = gameStateMock.Object, gameStateChecker = gameStateCheckerMock.Object };
        }

        [TestMethod()]
        public void GameStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Serialize_Returns_True_For_Good_GameState()
        {
            var createMockGameState = CreateMockGameState(true);
            var gameStateChecker = createMockGameState.gameStateChecker;
            var gameState = new GameState(gameStateChecker);
            var result = gameState.Serialize();
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),AllowDerivedTypes=false)]
        public void Serialize_Returns_False_For_Bad_GameState()
        {
            var createMockGameState = CreateMockGameState(false);
            var gameStateChecker = createMockGameState.gameStateChecker;
            var gameState = new GameState(gameStateChecker);
            var result = gameState.Serialize();
        }
    }
}
