using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Adapter;
using PS_Sample.Model;

namespace PS_Sample.Test
{
    [TestClass]
    public class MonkeyTest : AnimalTest<Monkey, RopeBridge>
    {
        [TestMethod]
        public void TestAddMonkeyToLeftSide()
        {
            var animal = new Monkey(this.Bridge, BridgeSide.Left);
            Assert.IsTrue(this.Bridge.LeftSideAnimalList.IndexOf(animal) > -1);
        }

        [TestMethod]
        public void TestAddMonkeyToRightSide()
        {
            var animal = new Monkey(this.Bridge, BridgeSide.Right);
            Assert.IsTrue(this.Bridge.RightSideAnimalList.IndexOf(animal) > -1);
        }
    }
}
