using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS_Sample.Model;

namespace PS_Sample.Test
{   
    public abstract class AnimalTest<TAnimal>
        where TAnimal : Animal, new()
    {
        
    }
}
