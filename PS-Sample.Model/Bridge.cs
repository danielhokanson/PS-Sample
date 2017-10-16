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
        public List<Animal> LeftCrossedAnimals { get; internal set; } = new List<Animal>();
        public List<Animal> RightCrossedAnimals { get; internal set; } = new List<Animal>();
        public Animal[][] CrossingAnimals { get; private set; }
        public short CrossingAnimalCount { get; internal set; }
        public short PositionCount { get; private set; }
        public short Capacity { get; private set; }
        public short LaneCount { get; private set; }
        public Bridge(short p_bridgePositionCount, short p_bridgeCapacity, short p_bridgeLaneCount = 1)
        {
            if (p_bridgePositionCount < 1)
            {
                throw new InvalidOperationException("The Bridge Position Count parameter(p_bridgePositionCount) provided to the Bridge cannot be less than one.");
            }
            if (p_bridgeCapacity < 1)
            {
                throw new InvalidOperationException("The Bridge Capacity parameter(p_bridgeCapacity) value provided to the Bridge cannot be less than one.");
            }
            if (p_bridgeLaneCount < 1)
            {
                throw new InvalidOperationException("The Bridge Lane Count parameter(p_bridgeLaneCount) provided to the Bridge cannot be less than one.");
            }
            this.PositionCount = p_bridgePositionCount;
            this.Capacity = p_bridgeCapacity;
            this.LaneCount = p_bridgeLaneCount;
            this.CrossingAnimals = new Animal[this.LaneCount][];
            for (var laneIndex = 0; laneIndex < this.LaneCount; laneIndex++)
            {
                this.CrossingAnimals[laneIndex] = new Animal[this.PositionCount];
            }
        }

    }
}
