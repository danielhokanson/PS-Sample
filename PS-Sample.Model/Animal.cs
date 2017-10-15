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
        public int AnimalId { get; private set; }
        public short MovementLimit { get; private set; }
        public DateTime? FirstInLineStamp { get; private set; }
        public virtual Animal Predecessor
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
        public short? BridgePosition
        {
            get
            {
                if (Bridge == null || Bridge.CrossingAnimals == null) {
                    return null;
                }
                for(var laneIndex = 0; laneIndex < Bridge.CrossingAnimals.Length; laneIndex++)
                {
                    
                }
                return null;
            }
        }
        internal List<Animal> Queue { get; set; }
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
            this.AnimalId = NextAnimalId++;
        }

        public virtual void TryMove()
        {
            if (LinePosition == 0)
            {

            }
            else
            {
                AnimalConsole.Insert(0, $"Animal:{this.GetType().Name}");
            }
        }
    }
}
