using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Sample.Model
{
    public abstract class Animal
    {
        public abstract int MovementLimit { get; internal set; }
        public virtual DateTime? FirstInLineStamp { get; set; }
        public virtual BridgeSide Side { get; set; }
        public virtual Animal Predecessor { get {
                if (_bridge == null || _sideList == null || _sideList.IndexOf(this) < 1)
                {
                    return null;
                }
                return _sideList[_sideList.IndexOf(this) - 1];
            } }
        public int LinePosition
        {
            get
            {
                if(_sideList == null)
                {
                    return -1;
                }
                return _sideList.IndexOf(this);
            }
        }
        protected List<Animal> _sideList;
        protected Bridge _bridge;
    }
    public abstract class Animal<TBridge> : Animal
        where TBridge : Bridge, new()
    {   
        
        public virtual TBridge Bridge { get { return _bridge as TBridge; } set { _bridge = value; } }
        

        public Animal(TBridge p_bridge, BridgeSide p_side)
        {
            Bridge = p_bridge;
            Side = p_side;
            InitAnimal();
        }

        private void InitAnimal()
        {
            switch (Side)
            {
                case BridgeSide.Unspecified:
                    throw new InvalidOperationException($"Animal:{this.GetType().Name} Cannot be created without specifying the side of the bridge.");
                case BridgeSide.Left:
                    _sideList = Bridge.LeftSideAnimalList;
                    break;
                case BridgeSide.Right:
                    _sideList = Bridge.RightSideAnimalList;
                    break;
            }
            _sideList.Add(this);
        }

        public virtual void TryMove()
        {
            
        }
    }
}
