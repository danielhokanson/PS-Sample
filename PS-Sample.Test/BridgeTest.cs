﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;
using PS_Sample.Adapter;
using System.Collections.Generic;

namespace PS_Sample.Test
{                   
    public abstract class BridgeTest<TBridge>
        where TBridge : Bridge, new()
    {   
        public TBridge Bridge { get; internal set; }

        public BridgeTest()
        {
            this.Bridge = new TBridge();
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

        [TestMethod]
        public void BridgeFullMoveTest()
        {
            var animalList = new List<Animal>();
            for(var monkeyIndex = 0; monkeyIndex < this.Bridge.Capacity * 4; monkeyIndex++)
            {
                var side = monkeyIndex % 2 == 1 ? BridgeSide.Left : BridgeSide.Right;
                var animal = new Monkey(this.Bridge, side);
                animalList.Add(animal);
            }
            foreach (var animalToMove in animalList)
            {
                animalToMove.TryMove();
            }
            var ableToMove = false;


            Assert.IsFalse(ableToMove);
        }
    }
}
