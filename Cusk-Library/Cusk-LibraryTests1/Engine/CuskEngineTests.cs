using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cusk_Library.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cusk_Library.Entities;
using Moq;
namespace Cusk_Library.Engine.Tests
{
    [TestClass()]
    public class CuskEngineTests
    {
        private CuskEngine cuskEngine;
        [TestInitialize()]
        public void Initialize()
        {
            cuskEngine = new CuskEngine(new CuskEntityDatabase(), new TimeSpan(50000)); //Very small ticks for testing - 5ms
        }

        [TestMethod()]
        public void CanMoveTo_Returns_True_When_New_Location_Is_Movable()
        {
            var mock = new Mock<ICuskEntity>();
            mock.Setup(m => m.CurrentX).Returns(0);
            mock.Setup(m => m.CurrentY).Returns(0);

            var mockNotBlocking = new Mock<ICuskEntity>();
            mockNotBlocking.Setup(m => m.CurrentX).Returns(2);
            mockNotBlocking.Setup(m => m.CurrentY).Returns(1);

            cuskEngine.cuskObjectDatabase.AddToDatabase(mockNotBlocking.Object);

            var result = cuskEngine.EntityCanMoveTo(1, 1, mock.Object);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CanMoveTo_Returns_False_When_New_Location_Is_Not_Movable()
        {
            var mock = new Mock<ICuskEntity>();
            mock.Setup(m => m.CurrentX).Returns(0);
            mock.Setup(m => m.CurrentY).Returns(0);

            var mockBlocking = new Mock<ICuskEntity>();
            mockBlocking.Setup(m => m.CurrentX).Returns(1);
            mockBlocking.Setup(m => m.CurrentY).Returns(1);

            cuskEngine.cuskObjectDatabase.AddToDatabase(mockBlocking.Object);


            var result = cuskEngine.EntityCanMoveTo(1, 1, mock.Object);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void RunTickTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tick length is {0}{1}", cuskEngine.TickMSLength, Environment.NewLine);
            sb.AppendFormat("Time is {0}{1}", DateTime.UtcNow, Environment.NewLine);
            cuskEngine.RunTick();
            sb.AppendFormat("Tick length is {0}{1}", cuskEngine.TickMSLength, Environment.NewLine);
            sb.AppendFormat("Time is {0}{1}", DateTime.UtcNow, Environment.NewLine);
            cuskEngine.RunTick();
            sb.AppendFormat("Tick length is {0}{1}", cuskEngine.TickMSLength, Environment.NewLine);
            sb.AppendFormat("Time is {0}{1}", DateTime.UtcNow, Environment.NewLine);
            cuskEngine.RunTick();
            sb.AppendFormat("Tick length is {0}{1}", cuskEngine.TickMSLength, Environment.NewLine);
            sb.AppendFormat("Time is {0}{1}", DateTime.UtcNow, Environment.NewLine);
            Assert.Inconclusive(sb.ToString());
        }
    }
}
