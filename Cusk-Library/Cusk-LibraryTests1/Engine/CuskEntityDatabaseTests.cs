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
        private ICuskEntityDatabase cuskEntityDatabase;
     
        private ICuskEntity CreateEntity(int CurrentX = 0, int CurrentY = 0)
        {
            var mock = new Mock<ICuskEntity>();
            mock.Setup(m => m.CurrentX).Returns(CurrentX);
            mock.Setup(m => m.CurrentY).Returns(CurrentY);
            return mock.Object;
        }
     
        private ICuskEntityDatabase CreateCuskEntityDatabase()
        {
            return new CuskEntityDatabase();
        }

        [TestInitialize()]
        public void Initialize()
        {
            cuskEntityDatabase = CreateCuskEntityDatabase();
        }
        [TestMethod()]
        public void AddToDatabase_Returns_True_For_New_Entity()
        {
            Assert.IsTrue(cuskEntityDatabase.AddToDatabase(CreateEntity()));
        }

        [TestMethod()]
        public void AddToDatabase_Returns_False_For_Existing_Entity()
        {
            var localCuskEntityDatabase = CreateCuskEntityDatabase();
            var cuskEntity = CreateEntity();
            localCuskEntityDatabase.AddToDatabase(cuskEntity);
            Assert.IsFalse(localCuskEntityDatabase.AddToDatabase(cuskEntity));
        }

        [TestMethod()]
        public void SerializeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEntityAtLoc_Returns_Correct_Entity_If_One_Matches()
        {
            var localCuskEntityDatabase = CreateCuskEntityDatabase();
            var cuskEntity = CreateEntity(5, 5);
            localCuskEntityDatabase.AddToDatabase(cuskEntity);
            var result = localCuskEntityDatabase.GetEntityAtLoc(5, 5);
            Assert.AreEqual(cuskEntity, result);
        }

        [TestMethod()]
        public void GetEntityAtLoc_Returns_Correct_Entity_If_One_Matches_At_Origin()
        {
            var localCuskEntityDatabase = CreateCuskEntityDatabase();
            var cuskEntity = CreateEntity(0, 0);
            localCuskEntityDatabase.AddToDatabase(cuskEntity);
            var result = localCuskEntityDatabase.GetEntityAtLoc(0, 0);
            Assert.AreEqual(cuskEntity, result);
        }

        [TestMethod()]
        public void IsEntityAtLoc_Returns_True_If_One_Matches()
        {
            var localCuskEntityDatabase = CreateCuskEntityDatabase();
            var cuskEntity = CreateEntity(5, 5);
            localCuskEntityDatabase.AddToDatabase(cuskEntity);
            var result = localCuskEntityDatabase.IsEntityAtLoc(5, 5);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsEntityAtLoc_Returns_False_If_None_Match()
        {
            var localCuskEntityDatabase = CreateCuskEntityDatabase();
            var cuskEntity = CreateEntity(5, 5);
            localCuskEntityDatabase.AddToDatabase(cuskEntity);
            var result = localCuskEntityDatabase.IsEntityAtLoc(4, 5);
            Assert.IsFalse(result);
        }

    }
}
