using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adapter
{
    internal class main
    {
        public static void Main(string[] args)
        {
            // Create an instance of ComputerGame
            ComputerGame game = new ComputerGame(
                "Epic Adventure",
                PegiAgeRating.P16,
                60, // Budget in millions
                4096, // Minimum GPU Memory in MB
                50, // Disk Space in GB
                16, // RAM Needed in GB
                4, // Cores Needed
                3.5 // Core Speed in GHz
            );

            // Use the adapter to access PCGame interface
            PCGame gameAdapter = new ComputerGameAdapter(game);

            // Display game details
            Console.WriteLine("Game Title: " + gameAdapter.getTitle());
            Console.WriteLine("PEGI Allowed Age: " + gameAdapter.getPegiAllowedAge());
            Console.WriteLine("Is Triple-A Game: " + gameAdapter.isTripleAGame());

            // Get requirements and display them
            Requirements requirements = gameAdapter.getRequirements();
            Console.WriteLine("Requirements:");
            Console.WriteLine("GPU: " + requirements.getGpuGb() + " GB");
            Console.WriteLine("Disk Space: " + requirements.getHDDGb() + " GB");
            Console.WriteLine("RAM: " + requirements.getRAMGb() + " GB");
            Console.WriteLine("CPU Speed: " + requirements.getCpuGhz() + " GHz");
            Console.WriteLine("Cores Needed: " + requirements.getCoresNum());
        }
    }
}
