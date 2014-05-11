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
            cuskEngine = new CuskEngine(new CuskEntityDatabase());
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

            var result = cuskEngine.CanMoveTo(1, 1, mock.Object);
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


            var result = cuskEngine.CanMoveTo(1, 1, mock.Object);
            Assert.IsFalse(result);
        }
    }
}
