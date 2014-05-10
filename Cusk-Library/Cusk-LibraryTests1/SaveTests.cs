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
    struct GameStateAndChecker
    {
        public IGameState gameState;
        public IGameStateChecker gameStateChecker;
    }

    [TestClass()]
    public class SaveTests
    {
        
        private GameStateAndChecker CreateMockGameState(bool GoodGameState=true)
        {
            var gameStateMock = new Mock<IGameState>();
            if (GoodGameState)
                gameStateMock.Setup(m => m.Serialize()).Returns(new object());
            else
                gameStateMock.Setup(m => m.Serialize()).Throws(new Exception());

            var gameStateCheckerMock = new Mock<IGameStateChecker>();
            return new GameStateAndChecker() { gameState = gameStateMock.Object, gameStateChecker= gameStateCheckerMock.Object };
         }

        [TestMethod()]
        public void Serialize_Returns_True_On_Good_GameState()
        {
            var save = new Save();
            //Set cusk_GameState to decent mock
            var gameStateAndChecker = CreateMockGameState(true);
            var gameState = gameStateAndChecker.gameState;
            var result = save.Serialize(gameState);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Serialize_Returns_False_On_Bad_GameState()
        {
            var save = new Save();
            //Set cusk_GameState to bad mock
            var gameStateAndChecker = CreateMockGameState(false);
            var gameState = gameStateAndChecker.gameState;
            var result = save.Serialize(gameState);
            Assert.IsFalse(result);
        }
    }
}
