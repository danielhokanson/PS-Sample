using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Sample.Model
{
    public abstract class Bridge
    {
        public List<Animal> LeftSideAnimalList { get; protected set; } = new List<Animal>();
        public List<Animal> RightSideAnimalList { get; protected set; } = new List<Animal>();
        public Animal[,] CrossingAnimals { get; internal set; }
        public short PositionCount { get; private set; }
        public short Capacity { get; private set; }
        protected short LaneCount { get; private set; }
        public Bridge(short p_bridgePositionCount, short p_bridgeCapactity, short p_bridgeLaneCount = 1)
        {
            this.PositionCount = p_bridgePositionCount;
            this.Capacity = p_bridgeCapactity;
            this.LaneCount = p_bridgeLaneCount;
            this.CrossingAnimals = new Animal[this.Capacity, this.LaneCount];
        }                                                                             
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
