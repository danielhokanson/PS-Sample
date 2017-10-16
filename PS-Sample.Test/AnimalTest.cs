using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;

namespace PS_Sample.Test
{   
    public abstract class AnimalTest<TAnimal, TBridge>
        where TAnimal : Animal
                where TBridge : Bridge, new()
    {
        public TBridge Bridge { get; set; }

        public AnimalTest()
        {
            this.Bridge = new TBridge();
        }
    }
}
