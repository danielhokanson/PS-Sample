using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;

namespace PS_Sample.Test
{                   
    public abstract class BridgeTest
    {   
        public Bridge Bridge { get; internal set; }

        public BridgeTest(Bridge p_bridge)
        {
            this.Bridge = p_bridge;
        }

       [TestMethod]
       public void TestHasBridgeCapacity()
        {
            var bridgeCapacityProp = typeof(Bridge).GetProperty("Capacity");
            Assert.IsTrue(bridgeCapacityProp != null && bridgeCapacityProp.PropertyType == typeof(short));
        }

        [TestMethod]
        public void TestHasBridgePositionCount()
        {
            var bridgePositionCountProp = typeof(Bridge).GetProperty("PositionCount");
            Assert.IsTrue(bridgePositionCountProp != null && bridgePositionCountProp.PropertyType == typeof(short));
        }  
    }
}
