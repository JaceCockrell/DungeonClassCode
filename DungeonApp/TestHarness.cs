using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Dungeon
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            Character c1 = new Character()
            {
                Name = "Atreus",
                MaxLife = 100,
                Life = 100,
                HitChance = 33,
                Block = 38
            };
            Console.WriteLine($"Name : {c1.Name}\n" +
                $"Max Life : {c1.MaxLife}\n" +
                $"Life : {c1.Life}\n" +
                $"Hit Chance : {c1.HitChance}%\n" +
                $"Block Power {c1.Block}");
        }
    }
}
