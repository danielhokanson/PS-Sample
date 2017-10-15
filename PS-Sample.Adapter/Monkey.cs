using PS_Sample.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Sample.Adapter
{
    public class Monkey : Animal
    {
        public Monkey(Bridge p_bridge, BridgeSide p_side) : base(p_bridge, p_side)
        {
            this.AvatarRelativePath = $"{new FileInfo(this.GetType().Assembly.Location).Directory}/resource/monkey.svg";
        }
    }
}
