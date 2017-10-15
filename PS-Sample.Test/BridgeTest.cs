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
            var bridgeCapacityProp = typeof(Bridge).GetProperty("Capactity");
            Assert.IsTrue(bridgeCapacityProp != null && bridgeCapacityProp.GetType() == typeof(short));
        }
    }
}
