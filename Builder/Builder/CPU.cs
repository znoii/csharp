using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class CPU
    {
            internal string Brand;
            public override string ToString()
            {
                return $"{Brand} GHz";
            }
        
    }
}
