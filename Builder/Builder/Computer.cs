using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Computer
    {
        internal CPU CPU { get; set; }
        internal Motherboard Motherboard { get; set; }
        internal RAM RAM { get; set; }
        internal Storage Storage { get; set; }
        internal GraphicsCard GraphicsCard { get; set; }

        internal Computer(ComputerBuilder builder)
        {
            this.CPU = builder.cCPU;
            this.Motherboard = builder.cMotherboard;
            this.RAM = builder.cRAM;
            this.Storage = builder.cStorage;
            this.GraphicsCard = builder.cGraphicsCard;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.Append($"There are {this.CPU}, {this.Motherboard}, {this.RAM}, {this.Storage}, and {this.GraphicsCard} in your computer.");
            return sb.ToString();
        }
    }
}
