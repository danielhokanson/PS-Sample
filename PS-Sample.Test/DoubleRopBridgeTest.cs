using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;
using PS_Sample.Adapter;

namespace PS_Sample.Test
{
    [TestClass]
    public class DoubleRopeBridgeTest : BridgeTest<DoubleRopeBridge>
    {                                                               
        [TestMethod]
        public void DoubleRopeBridgeLaneCountTest()
        {
            Assert.IsTrue(this.Bridge.LaneCount == 2);
        }

        [TestMethod]
        public void DoubleRopeBridgeCapacityTest()
        {
            Assert.IsTrue(Bridge.Capacity == 6);
        }

        [TestMethod]
        public void DoubleRopeBridgePositionCountTest()
        {
            Assert.IsTrue(Bridge.PositionCount == 4);
        }
    }
}
