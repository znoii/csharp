using Builder;
using System;

namespace ComputerBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerBuilder builder = new ComputerBuilder();
            Computer computer = builder
                .SetCPU(new CPU { Brand = "Intel"})
                .SetMotherboard(new Motherboard { Socket = "JNC 1200"})
                .SetRAM(new RAM { Size = 16 })
                .SetStorage(new Storage { Capacity = 1000 })
                .SetGraphicsCard(new GraphicsCard { Model = "NVIDIA GeForce 9090", Memory = 8 })
                .Build();

            Console.WriteLine(computer.GetDescription());
            Console.ReadLine();
        }
    }
}
