using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
                if (Bridge == null || Lane == null || Array.IndexOf(Lane, this) < 0 || Array.IndexOf(Lane, this) + 1 >= this.Bridge.PositionCount)
                {
                    return null;
                }
                return Lane[Array.IndexOf(Lane, this) + 1];
            }
        }
        public int? BridgePosition
        {
            get
            {
                if (Bridge == null || Bridge.CrossingAnimals == null || Lane == null || Array.IndexOf(this.Lane, this) < -1)
                {
                    return null;
                }
                return Array.IndexOf(this.Lane, this);
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
            this.Queue.Add(this);
            this.Id = NextAnimalId++;
        }

        public bool TryMove()
        {
            bool movementWasSuccess = false;

            using (TransactionScope movementScope = new TransactionScope())
            {
                if (!LinePosition.HasValue)
                {
                    movementWasSuccess = MoveAnimalInBridgeLane();
                }
                else if (LinePosition == 0)
                {
                    movementWasSuccess = MoveHeadofQueueAnimal();
                }
                else
                {
                    AnimalConsole.Insert(0, $"Animal({this.Id}):{this.GetType().Name}: has to wait. It is not at the front of the line.");
                    movementWasSuccess = false;
                }
                movementScope.Complete();
            }
            return movementWasSuccess;
        }

        private bool MoveAnimalInBridgeLane()
        {
            if (Lane == null || !BridgePosition.HasValue)
            {
                var error = $"Animal({this.Id}):{this.GetType().Name}: Something went wrong. This Animal is not in a Queue and is not currently in a bridge lane. Cannot move";
                AnimalConsole.Insert(0, error);
                return false;
            }

            var currentPosition = Array.IndexOf(this.Lane, this);
            var isFinishedCrossing = false;
            if (BridgePredecessor == null)
            {
                if (Lane.Last() == this)
                {
                    switch (this.Side)
                    {
                        case BridgeSide.Left:
                            this.Bridge.LeftCrossedAnimals.Add(this);
                            break;
                        case BridgeSide.Right:
                            this.Bridge.RightCrossedAnimals.Add(this);
                            break;
                        default:
                            var error = $"Animal({this.Id}):{this.GetType().Name}: Something went wrong. This Animal has already completed crossing the bridge. Cannot move.";
                            AnimalConsole.Insert(0, error);
                            return false;
                    }

                    this.Side = BridgeSide.Unspecified;
                    this.Bridge.CrossingAnimalCount--;
                    isFinishedCrossing = true;
                }
                else
                {                    
                    this.Lane[currentPosition + 1] = this;       
                }
                this.Lane[currentPosition] = null;
                AnimalConsole.Insert(0, $"Animal({this.Id}):{this.GetType().Name}: Moved Successfully.");
                if (isFinishedCrossing)
                {
                    AnimalConsole.Insert(0, $"Animal({this.Id}):{this.GetType().Name}: Finished Crossing.");
                    this.Lane = null;
                }
                return true;
            }
            AnimalConsole.Insert(0, $"Animal({this.Id}):{this.GetType().Name}: has to wait. The bridge position in front of it is occupied.");
            return false;
        }

        private bool MoveHeadofQueueAnimal()
        {
            if (Bridge.CrossingAnimalCount == Bridge.Capacity)
            {
                AnimalConsole.Insert(0, $"Animal({this.Id}):{this.GetType().Name}: has to wait. The bridge is at capacity.");
                return false;
            }
            else
            {
                foreach (Animal[] lane in this.Bridge.CrossingAnimals)
                {
                    int laneOccupants = 0;
                    BridgeSide currentOccupantSide = BridgeSide.Unspecified;
                    foreach (Animal crossingAnimal in lane)
                    {
                        laneOccupants += (crossingAnimal != null) ? 1 : 0;
                        if (crossingAnimal != null && currentOccupantSide == BridgeSide.Unspecified)
                        {
                            currentOccupantSide = crossingAnimal.Side;
                        }
                    }
                    if (laneOccupants == 0)
                    {
                        currentOccupantSide = this.Side;                        
                    }
                    if (currentOccupantSide == this.Side || lane[0] == null)
                    {
                        this.Lane = lane;
                        this.Lane[0] = this;
                        this.Queue.Remove(this);
                        this.Bridge.CrossingAnimalCount++;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
