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
        public BridgeSide LastEntrantSide { get; internal set; } = BridgeSide.Unspecified;
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
        public bool ProcessAnimalMovement()
        {
            bool didAnyoneMove = false;
            foreach(Animal[] lane in this.CrossingAnimals.Where(lane=>lane.Any(animal=>animal != null)))
            {
                var animalsInLane = lane.Where(animal => animal != null);
                foreach(Animal animal in animalsInLane.OrderBy(animal=>animal.Id))
                {
                    didAnyoneMove = animal.TryMove() ? true : didAnyoneMove;
                }
            }
            if (LeftSideAnimalList.Any())
            {
                didAnyoneMove = LeftSideAnimalList.First().TryMove() ? true : didAnyoneMove;
            }
            if (RightSideAnimalList.Any())
            {
                didAnyoneMove = RightSideAnimalList.First().TryMove() ? true : didAnyoneMove;
            }
            return didAnyoneMove;
        }
    }
}
