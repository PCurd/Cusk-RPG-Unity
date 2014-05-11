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
    public class CuskEntityDatabaseTests
    {
        private CuskEntityDatabase cuskEntityDatabase;
     
        private ICuskEntity CreateEntity()
        {
            return new LivingThing(1,1,1,1,1,1,1,new Mock<ICuskEngine>().Object);
        }
        [TestInitialize()]
        public void Initialize()
        {
            cuskEntityDatabase = new CuskEntityDatabase();
        }
        [TestMethod()]
        public void AddToDatabase_Returns_True_For_New_Entity()
        {
            Assert.IsTrue(cuskEntityDatabase.AddToDatabase(CreateEntity()));
        }

        [TestMethod()]
        public void AddToDatabase_Returns_False_For_Existing_Entity()
        {
            var cuskEntity = CreateEntity();
            cuskEntityDatabase.AddToDatabase(cuskEntity);
            Assert.IsTrue(cuskEntityDatabase.AddToDatabase(cuskEntity));
        }

        [TestMethod()]
        public void SerializeTest()
        {
            Assert.Fail();
        }

    }
}
