﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Motherboard
    {
        internal string Socket;
        public override string ToString()
        {
            return $"{Socket}";
        }
    }
}
