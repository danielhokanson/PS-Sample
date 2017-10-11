using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Sample.Model
{
    public abstract class Bridge
    {
        public HashSet<Animal> LeftSideAnimalList { get; protected set; } = new HashSet<Animal>();
        public HashSet<Animal> RightSideAnimalList { get; protected set; } = new HashSet<Animal>();
        public abstract IPosition[] BridgePositionList { get; protected set; }
        public abstract Int16 Capacity { get; internal set; }
        public void AddAnimal(BridgeSide p_side, Animal p_animalToAdd)
        {
            if (p_side == BridgeSide.Left)
            {
                LeftSideAnimalList.Add(p_animalToAdd);
            }
            else
            {
                RightSideAnimalList.Add(p_animalToAdd);
            }
        }
    }
}
