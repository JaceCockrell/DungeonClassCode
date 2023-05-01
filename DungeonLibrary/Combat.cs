using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Combat
    {
        //This is not a DataType class so we will not have field props or constructors its going to be a warehouse of methods

        //Handle one side of the attack.
        public static void DoAttack(Character attacker, Character defender)
        {
            //Adjust the hit chance 
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            //Roll a random number between 1-100
            Random rand = new Random();
            int roll = rand.Next(1, 101);
            //Attack is successful if roll is less than adjusted hit chance.
            if (roll <= chance) 
            {
                //Calculate the damage
                int damage = attacker.CalcDamage();
                #region Potential expansion - crits
                //if Roll == 100, the increase damage by something.
                //damage *= 2
                #endregion
                //subtract that the damage from the defenders life
                defender.Life -= damage;
                //output the result
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();
            }

            else//attacker missed
            {
                Console.WriteLine($"{attacker.Name} missed!");
                //Console.WriteLine("Roll " + roll);
                //Console.WriteLine( "Chance: " + chance);
            }


        }

        //Handle one Round of battle Attacks from both sides.
        public static void DoBattle(Player player, Monster monster)
        {
            //for this example the player always goes first 
            DoAttack(player, monster);
            //if the monster survives let them attack
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
