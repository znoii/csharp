using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    using System;
    using System.Drawing;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Text;
    
    class ComputerBuilder
    {
        internal CPU cCPU;
        internal Motherboard cMotherboard;
        internal RAM cRAM;
        internal Storage cStorage;
        internal GraphicsCard cGraphicsCard;

        internal ComputerBuilder()
        {
        }

        internal ComputerBuilder SetCPU(CPU cpu)
        {
            cCPU = cpu;
            return this;
        }

        internal ComputerBuilder SetMotherboard(Motherboard motherboard)
        {
            cMotherboard = motherboard;
            return this;
        }

        internal ComputerBuilder SetRAM(RAM ram)
        {
            cRAM = ram;
            return this;
        }

        internal ComputerBuilder SetStorage(Storage storage)
        {
            cStorage = storage;
            return this;
        }

        internal ComputerBuilder SetGraphicsCard(GraphicsCard graphicsCard)
        {
            cGraphicsCard = graphicsCard;
            return this;
        }

        internal Computer Build()
        {
            return new Computer(this);
        }
    }
}
