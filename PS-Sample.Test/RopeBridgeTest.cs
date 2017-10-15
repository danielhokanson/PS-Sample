using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;
using PS_Sample.Adapter;

namespace PS_Sample.Test
{
    [TestClass]
    public class RopeBridgeTest  : BridgeTest<RopeBridge>
    {    
        [TestMethod]
        public void RopeBridgeLaneCountTest()
        {
            Assert.IsTrue(this.Bridge.LaneCount == 1);
        }

        [TestMethod]
        public void RopeBridgeCapacityTest()
        {
            Assert.IsTrue(Bridge.Capacity == 3);
        }

        [TestMethod]
        public void RopeBridgePositionCountTest()
        {
            Assert.IsTrue(Bridge.PositionCount == 4);
        }
    }
}
