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
        public void MoveToTest()
        {
            Assert.Fail();
        }
    }
}
