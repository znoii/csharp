using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class GraphicsCard
    {
        internal string Model { get; set; }
        internal int Memory { get; set; }

        public override string ToString()
        {
            return $"{Model} with {Memory} MB memory";
        }
    }
}
