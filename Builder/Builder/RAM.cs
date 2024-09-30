using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class RAM
    {
        internal int Size;
        public override string ToString()
        {
            return $"{Size} GB ";
        }
    }
}
