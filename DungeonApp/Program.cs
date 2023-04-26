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

            //TODO - variable to keep score

            //TODO - Create a weapon

            //TODO - Create a Player

            //Main Game Loop
            bool lose = false;//Main Game Loop
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());

                //TODO - Generate a monster
                #region Main Menu
                //Encounter/Menu Loop 
                bool reload = false;//Encounter/Menu Loop 
                do
                {
                    //Print the Menu
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A. Attack\n" +
                        "R. Run Away\n" +
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
                        case ConsoleKey.A://TODO Combat
                            break;
                        case ConsoleKey.R://TODO Run Away
                            Console.WriteLine("Run Away!!");
                            reload = true;
                            break;
                        case ConsoleKey.P://TODO Player
                            break;
                        case ConsoleKey.M://TODO Monster
                            break;
                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.WriteLine("No one likes a quitter!");
                            lose= true;
                            break;
                        default:
                            Console.WriteLine("\aWhat does that even mean!? Try again, but better..");
                            break;
                    }//end switch
                    //TODO Check player life. if dead GAME OVER
                } while (!reload && !lose);//While reload and lose are both false keep looping

                #endregion

            } while (!lose);// while lose is false keep looping

            //Output final score
        }//main()

        //TODO GetRoom() returns string (kinda like magic 8 ball lab)
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


    }//program
}//name