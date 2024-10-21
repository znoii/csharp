using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class main
    {
        public static void Main(string[] args)
        {
            ComputerGame game = new ComputerGame(
                "Hoh",
                PegiAgeRating.P16,
                60, // в млн
                4096, 
                50, 
                16, 
                4,
                3.5 
            );

            PCGame gameAdapter = new ComputerGameAdapter(game);

            // Display game details
            Console.WriteLine("Название: " + gameAdapter.getTitle());
            Console.WriteLine("Pegi Age: " + gameAdapter.getPegiAllowedAge());
            Console.WriteLine("Triple-A Game: " + gameAdapter.isTripleAGame());

            Requirements requirements = gameAdapter.getRequirements();
            Console.WriteLine("Требования:");
            Console.WriteLine("GPU: " + requirements.getGpuGb() + " GB");
            Console.WriteLine("Disk Space: " + requirements.getHDDGb() + " GB");
            Console.WriteLine("RAM: " + requirements.getRAMGb() + " GB");
            Console.WriteLine("CPU Speed: " + requirements.getCpuGhz() + " GHz");
            Console.WriteLine("Cores: " + requirements.getCoresNum());
        }
    }
}
