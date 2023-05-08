using DungeonLibrary;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            //Start to play backround music? (.wav) < 100MB
            //System.Windows.Extensions (NuGet package)
            Console.Title = "GOW Em";
            Console.WriteLine("Welcome, Adventurer! Your Journey begins!\n\n");
            Console.WriteLine("What is your name?");
            string usrName = Console.ReadLine();
            Console.Clear();



            #endregion
            // - variable to keep score
            int score = 0;


            // - Create a weapon
            Weapon wep0 = new("Leviathan Axe", 6, 10, 12, true, WeaponType.A_Axe);
            Weapon wep1 = new("Blades of Chaos", 4, 12, 10, true, WeaponType.B_Daggers);
            Weapon wep2 = new("Guardian Shield", 2, 14, 33, false, WeaponType.C_Bare_Hands);
            Weapon wep3 = new("Spear & Wings", 4, 12, 8, true, WeaponType.D_Valkyrie_Armor);
            Weapon wep4 = new("Atreus Bow", 4, 12, 15, true, WeaponType.E_Bow);
            Weapon wep5 = new("Naked", 1, 3, 15, false, WeaponType.Naked); 

            Console.WriteLine("You are going to need to defend yourself " + usrName + "," + "\nbased on your decision I will give you a weapon of that type.\nPlease enter the letter before the weapon type you wish to choose...\n\n");

            List<Weapon> weapons = new() { wep0, wep1, wep2, wep3, wep4 };// add protections
            int index = 1;

            foreach (Weapon item in weapons)
            {
                string weaponType = item.WeaponType.ToString().Replace("_"," ");
                Console.WriteLine(weaponType);
                index++;
            }
            string userChoice = Console.ReadLine();

            Weapon userWeapon = wep5;

            if(userChoice.ToLower() == "a" || userChoice.ToLower() == "axe")
            {
                userWeapon = wep0;
            }
            else if (userChoice.ToLower() == "b" || userChoice.ToLower() == "daggers")
            {
                userWeapon = wep1;
            }
            else if (userChoice.ToLower() == "c" || userChoice.ToLower() == "bare hands")
            {
                userWeapon = wep2;
            }
            else if (userChoice.ToLower() == "d" || userChoice.ToLower() == "valkyrie armor")
            {
                userWeapon = wep3;
            }
            else if (userChoice.ToLower() == "e" || userChoice.ToLower() == "bow")
            {
                userWeapon = wep4;
            }

            Console.Clear();


            
            /*
             * ClassicMonsters[] monsters = Enum.GetValues<ClassicMonsters>();                                           //.GetValues(typeof(ClassicMonsters))            foreach (ClassicMonsters item in monsters)            {                //If we build multi-word enum values, it's best to use underscores _ for spaces.                //This makes it easy to replace.                string formattedItem = item.ToString().Replace('_', ' ');                //The only other way to do this would be with a regular expression, which can be error prone and difficult to understand. NOTE, for this example to work, all classic monsters must be PascalCase rather than _ for spaces.                //string formattedItem = Regex.Replace(item.ToString(), "(\\B[A-Z])", " $1");                Console.WriteLine($"{(int)item + 1} - {formattedItem}");            }            Console.Write("\nChoose a classic monster from the list above (enter the number only): ");            int userChoice = Convert.ToInt32(Console.ReadLine());            ClassicMonsters userMonster = (ClassicMonsters)(userChoice - 1);
             */
            Console.WriteLine("What Race will you choose? \nPlease enter the letter before the Race you wish to choose...\n");
            Race[] races = Enum.GetValues<Race>();//csf2 block3 enums.cs classicmonsters into an array list 
            foreach (Race race in races)
            {
                Console.WriteLine($"{race.ToString().Replace("_", " ")}");
            }

            string usrRace = Console.ReadLine();

            Race userRace = Race.A_Olympians;

            if (usrRace.ToLower() == "a" || usrRace.ToLower() == "olympians")
            {
                userRace = Race.A_Olympians;
            }
            else if (usrRace.ToLower() == "b" || usrRace.ToLower() == "giants")
            {
                userRace = Race.B_Giants;
            }
            else if (usrRace.ToLower() == "c" || usrRace.ToLower() == "titans")
            {
                userRace = Race.C_Titans;
            }
            else if (usrRace.ToLower() == "d" || usrRace.ToLower() == "valkyries")
            {
                userRace = Race.D_Valkyries;
            }
            else if (usrRace.ToLower() == "e" || usrRace.ToLower() == "helwalkers")
            {
                userRace = Race.E_HelWalkers;
            }

            Console.Clear();
            // - Create a Player Object
            //********************Recomended expansion let the user pick and chose name and race**************************

            Player player = new Player(usrName, 50, 30, 70, userRace, userWeapon);

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
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\a\aYou died...");
                        lose = true;
                    }//TODO see if score % 5 == 0 either heal or add new menu piece this will appear every + 5 to score
                } while (!reload && !lose);//While reload and lose are both false keep looping

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
            Draugr m1 = new Draugr("Draugr", 30, 25, 20, 1, 8, "Undead creatures that come in various types and have different abilities.", true);
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
