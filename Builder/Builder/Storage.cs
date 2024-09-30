using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Storage
    {
        internal int Capacity { get; set; }

        public override string ToString()
        {
            return $"{Capacity} GB ";
        }
    }
}
