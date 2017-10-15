using PS_Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Sample.Adapter
{
    public class DoubleRopeBridge : Bridge
    {
        public DoubleRopeBridge() : base(4/**only four positions available**/, 6/**six total positions, double that of a "rope bridge"**/, 2/**Two lanes of travel**/)
        {
        }
    }
}
