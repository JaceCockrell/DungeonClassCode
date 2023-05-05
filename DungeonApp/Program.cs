using DungeonLibrary;
using System.Net.Http.Headers;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            //Start to play backround music? (.wav) < 100MB
            //System.Windows.Extensions (NuGet package)
            Console.Title = "DUNGEON OF DOOM!";
            Console.WriteLine("Welcome, Adventurer! Your Journey begins!");

            #endregion

            // - variable to keep score

            int score = 0;
            //TODO - Create a weapon
            Weapon wep0 = new("Leviathan Axe", 3, 8, 12, true, WeaponType.Axe);
            Weapon wep1 = new("Blades of Chaos", 2, 10, 10, true, WeaponType.Daggers);
            Weapon wep2 = new("Guardian Shield", 1, 8, 33, false, WeaponType.Bare_Hands);
            Weapon wep3 = new("Spear & Wings", 2, 12, 8, true, WeaponType.Valkyrie_Armor);
            Weapon wep4 = new("Atreus Bow", 2, 12, 15, true, WeaponType.Bow);

            List<Weapon> weapons = new() { wep0, wep1, wep2, wep3, wep4 };
            int index = 1;
            foreach (var item in weapons)
            {
                Console.WriteLine(index + "" + item.WeaponType); 
            }

            // - Create a Player Object
            //Recomended expansion let the user pick and chose name and race
            Player player = new Player("Kratos", 70, 40, 50, Race.Olympians, wep1);

            //Main Game Loop
            bool lose = false;//Main Game Loop
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());
                Monster monster = GetMonster();
                Console.WriteLine("In this room: " + monster);
                //TODO - Generate a monster
                #region Main Menu
                //Encounter/Menu Loop 
                bool reload = false;//Encounter/Menu Loop 
                do
                {
                    //Print the Menu
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A. Attack\n" +
                        "R. Run Away - Enemy may have a chance to attack..\n" +
                        "P. Player Info\n" +
                        "M. Monster Info\n" +
                        "X. Exit");
                    //Capture their selection
                    ConsoleKey choice = Console.ReadKey(true).Key;
                    //Clear the console
                    Console.Clear();
                    //switch
                    switch (choice)
                    {
                        case ConsoleKey.A:// Combat
                            Combat.DoBattle(player, monster);
                            //check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou killed {monster.Name}\n");
                                Console.ResetColor();
                                reload = true;
                                score++;
                                //could add rewards
                            }
                            break;
                        case ConsoleKey.R:// Run Away
                            Console.WriteLine("Run Away!!");
                            //Attack of oppertunity
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;
                        case ConsoleKey.P:// Player
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Progress: You have defeated " + score + " monsters.");
                            break;
                        case ConsoleKey.M:// Monster
                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.WriteLine("No one likes a quitter!");
                            lose = true;
                            break;
                        default:
                            Console.WriteLine("\aWhat does that even mean!? Try again, but better..");
                            break;
                    }//end switch
                    // Check player life. if dead GAME OVER
                } while (!reload && !lose);//While reload and lose are both false keep looping

                if (player.Life <= 0)
                {
                    Console.WriteLine("\a\aYou died...");
                    lose = true;
                }
                #endregion

            } while (!lose);// while lose is false keep looping

            //Output final score
            Console.WriteLine("You have defeated " + score + $" monster{(score == 1 ? "." : "s.")}");
        }//main()

        //GetRoom() returns string (kinda like magic 8 ball lab)
        private static string GetRoom()
        {
            //create string[]
            string[] rooms =
            {
                "Helheim: A frozen and desolate realm filled with lost souls and icy mountains, where the dead wander aimlessly in the darkness.",
                "Alfheim: A bright and mystical realm of natural beauty, where the light of the elves shines and ancient ruins and portals are scattered throughout.",
                "Muspelheim: A fiery and dangerous realm of molten lava, filled with demonic creatures and deadly obstacles that challenge even the bravest warriors.",
                "Niflheim: A realm of poisonous mist and cursed treasures, where the souls of the dead suffer and the undead rise to haunt the living.",
                "Jotunheim: A realm of giants, towering mountains, and ancient ruins, where the secrets of the giants and the fate of the gods are entwined.",
                "Athens: A city steeped in the history and mythology of ancient Greece, where the streets are filled with danger and adventure, and the gods themselves may intervene in mortal affairs.",
            };
            //rng
            Random rand = new Random();
            int index = rand.Next(rooms.Length);
            //return a room using rng
            return rooms[index];
            //Refactoring
            //return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom
        private static Monster GetMonster()
        {
            Draugr m1 = new Draugr("Draugr", 50, 40, 20, 1, 8, "Undead creatures that come in various types and have different abilities.", true);
            Draugr m2 = new Draugr();
            Revenant m3 = new Revenant("Revenant", 30, 40, 15, 1, 6, "Ghost-like enemies that are difficult to hit and can move quickly.", false);
            Revenant m4 = new Revenant();
            Troll m5 = new Troll("War Troll ", 60, 30, 12, 1, 8, " Large, powerful enemies that can deal heavy damage and require different strategies to defeat.", true);
            Troll m6 = new Troll();
            Ancient m7 = new Ancient("Ancient Gaurdian", 55, 30, 25, 1, 6, "Ancient robotic beings that possess powerful elemental attacks.", true);
            Ancient m8 = new Ancient();

            Monster[] monsters =
            {
                m1,
                m2,m2,
                m3,
                m4,
                m5,
                m6,m6,m6,m6,
                m7,m7,
                m8,m8,m8
            };

            return monsters[new Random().Next(monsters.Length)];
        }

    }//program
}//name