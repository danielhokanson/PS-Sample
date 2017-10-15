using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Sample.Model
{
    public abstract class Animal
    {   
        public static int NextAnimalId = 0;
        public static List<string> AnimalConsole { get; private set; } = new List<string>();
        public int Id { get; private set; }
        public string AvatarRelativePath { get; set; }
        public short MovementLimit { get; private set; }
        public DateTime? FirstInLineStamp { get; private set; }
        public BridgeSide Side { get; private set; }
        public virtual Animal QueuePredecessor
        {
            get
            {
                if (Bridge == null || Queue == null || Queue.IndexOf(this) < 1)
                {
                    return null;
                }
                return Queue[Queue.IndexOf(this) - 1];
            }
        }
        public int? LinePosition
        {
            get
            {
                if (Bridge == null || Queue == null || Queue.IndexOf(this) < 0)
                {
                    return null;
                }
                return Queue.IndexOf(this);
            }
        }
        public Animal BridgePredecessor
        {
            get
            {
                if(Bridge == null || Lane == null || Array.IndexOf(Lane,this) < 0)
                {   
                    return null;
                }
                return Lane[Array.IndexOf(Lane, this) - 1];
            }
        }
        public short? BridgePosition
        {
            get
            {
                if (Bridge == null || Bridge.CrossingAnimals == null) {
                    return null;
                }
                for(var laneIndex = 0; laneIndex < Bridge.LaneCount; laneIndex++)
                {                                              
                    var lane = Bridge.CrossingAnimals[laneIndex];
                }
                return null;
            }
        }
        internal List<Animal> Queue { get; private set; }
        internal Animal[] Lane { get; private set; }
        internal Bridge Bridge { get; set; }
        public Animal(Bridge p_bridge, BridgeSide p_side, short p_animalMovementLimit = 1)
        {
            this.Bridge = p_bridge;
            if (p_side == BridgeSide.Left)
            {
                this.Queue = this.Bridge.LeftSideAnimalList;

            }
            else if (p_side == BridgeSide.Right)
            {
                this.Queue = this.Bridge.RightSideAnimalList;
            }
            else
            {
                throw new InvalidOperationException("An animal cannot be initialized without specifying qhich side oif the bridge it is on.");
            }
            this.Side = p_side;
            this.Id = NextAnimalId++;
        }

        public bool TryMove()
        {
            if (LinePosition == 0)
            {
                
            }
            else
            {
                AnimalConsole.Insert(0, $"Animal({this.Id}):{this.GetType().Name}: has to wait. It is not at the front of the line.");
            }
            return false;
        }
    }
}
