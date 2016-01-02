using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cusk_Library.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cusk_Library.Engine;
using Moq;
namespace Cusk_Library.Entities.Tests
{
    [TestClass()]
    public class LivingThingTests
    {
        private CuskEngine cuskEngine;
        private CuskEngine CreateMockCuskEngine()
        {
            var mock = new Mock<CuskEngine>();

            return mock.Object;
        }
        [TestInitialize()]
        private void Initialize()
        {
            cuskEngine = CreateMockCuskEngine();
        }

        [TestMethod()]
        public void LivingThing_Stores_Values_When_Created()
        {
            int MaxHP = 10;
            int MaxMP = 11;
            int Strength = 12;
            int Intelligence = 13;
            int Dexterity = 14;
            int Consitution = 15;
            int Wisdom = 16;
            var thing = new LivingThing(MaxHP, MaxMP, Strength, Intelligence, Dexterity, Consitution, Wisdom, cuskEngine);

            Assert.AreEqual(MaxHP, thing.HP);
            Assert.AreEqual(MaxMP, thing.MP);
            Assert.AreEqual(Strength, thing.Strength);
            Assert.AreEqual(Intelligence, thing.Intelligence);
            Assert.AreEqual(Dexterity, thing.Dexterity);
            Assert.AreEqual(Consitution, thing.Constitution);
            Assert.AreEqual(Wisdom, thing.Wisdom);
            Assert.AreEqual(0, thing.OriginalX);
            Assert.AreEqual(0, thing.OriginalY);
            Assert.AreEqual(0, thing.Experience);
            Assert.IsNotNull(thing.ID);
        }

        [TestMethod()]
        public void SerializeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MoveTo_Returns_True_When_Object_Moves()
        {
            var thing = CreateLivingThingThatCanMove();
            var result = thing.MoveTo(1,1);
            Assert.IsTrue(result);
        }

        private static LivingThing CreateLivingThingThatCanMove()
        {
            var mock = new Mock<ICuskEngine>();
            mock.Setup(m => m.EntityCanMoveTo(1, 1, It.IsAny<ICuskEntity>())).Returns(true);

            var thing = new LivingThing(1, 1, 1, 1, 1, 1, 1, mock.Object);
            return thing;
        }

        private static LivingThing CreateLivingThingThatCanMoveAnywhere()
        {
            var mock = new Mock<ICuskEngine>();
            mock.Setup(m => m.EntityCanMoveTo(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ICuskEntity>())).Returns(true);

            var thing = new LivingThing(1, 1, 1, 1, 1, 1, 1, mock.Object);
            return thing;
        }

        [TestMethod()]
        public void MoveTo_Returns_False_When_Object_Does_Not_Move()
        {
            var thing = new LivingThing(1, 1, 1, 1, 1, 1, 1, new Mock<ICuskEngine>().Object);
            var result = thing.MoveTo(0, 0);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void MoveTo_Returns_False_When_Object_Is_Blocked()
        {
            var mock = new Mock<ICuskEngine>();
            mock.Setup(m => m.EntityCanMoveTo(1, 1, It.IsAny<ICuskEntity>())).Returns(false);

            var thing = new LivingThing(1, 1, 1, 1, 1, 1, 1, mock.Object);
            var result = thing.MoveTo(1, 1);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void DoMovesTest()
        {
            var thing = CreateLivingThingThatCanMoveAnywhere();
            var locX = thing.CurrentX;
            thing.DoMoves();
            Assert.IsTrue(thing.CurrentX>locX);
        }
    }
}
