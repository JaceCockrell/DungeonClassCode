using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DungeonLibrary;

namespace Dungeon
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            //Character c1 = new Character()
            //{
            //    Name = "Atreus",
            //    MaxLife = 100,
            //    HitChance = 33,
            //    Block = 38
            // };
            // Console.WriteLine($"Name : {c1.Name}\n" +
            //     $"Max Life : {c1.MaxLife}\n" +
            //     $"Life : {c1.Life}\n" +
            //     $"Hit Chance : {c1.HitChance}%\n" +
            //    $"Block Power {c1.Block}\n\n");



            //Console.WriteLine("\n");
            //Console.WriteLine(w1);
            //TODO test player creation and TOString(), calcblock, calcdamage, calhitchance
            //TODO test monster creation and ToString(), calcblocl, calcdamage, calchitchance
            Weapon w1 = new Weapon("Atreus' Compact bow", 1, 10, 0, true, WeaponType.Bow);
            Player player = new Player($"Atreus", 80, 20, 100, Race.Giants, w1);
            Monster m1 = new Monster($"Test Monster", 50, 40, 20, 1, 8, "He doesn't even know what a test is..");

            
            while (true)
            {
                Combat.DoBattle(player, m1);
                Console.WriteLine("Player Life: " + player.Life);
                Console.WriteLine("Monster Life: " + m1.Life);
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
