using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;

namespace PS_Sample.Test
{
    [TestClass]
    public class BridgeTest
    {   
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
