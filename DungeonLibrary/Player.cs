using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon EquipedWeapon { get; set; }

        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, Weapon equippedWeapon ) : base(name, hitChance, block, maxLife)
        {
           PlayerRace = playerRace;
            EquipedWeapon = equippedWeapon;
            #region Possible expansion

            //In program.cs you will have to show the user a list of races of races and let them pick one
            //ref to this is in CSF2 Enums.cs for ClassicMonsters
            #region (PlayerRace)
            switch (PlayerRace)
            {
                case Race.A_Olympians:
                    HitChance += 6;
                    break;
                case Race.B_Giants:
                    EquipedWeapon.MaxDamage += 8;
                    break;
                case Race.C_Titans:
                    HitChance += 8;
                    break;
                case Race.D_Valkyries:
                    Block += 6;
                    break;
                case Race.E_HelWalkers:
                    MaxLife += 10;
                    break;
                default:
                    break;
            }
            #endregion
            #endregion
        }// end ctor
        public Player() { }
        public override string ToString()
        {
            string raceDescription = "";
            switch (PlayerRace)
            {
                case Race.A_Olympians: raceDescription =" Olympian - The powerful and godly rulers of Mount Olympus.";
                    break;
                case Race.B_Giants: raceDescription =" Giant - Massive and ancient beings with incredible strength and magical abilities.";
                    break;
                case Race.C_Titans:raceDescription =" Titian - Gigantic and powerful deities that predate the gods and goddesses of Mount Olympus.";
                    break;
                case Race.D_Valkyries:raceDescription =" Valkyrie - Noble warrior maidens who serve the gods and guide the souls of fallen heroes to Valhalla.";
                    break;
                case Race.E_HelWalkers:raceDescription =" Hel-Walker - Undead warriors cursed by the goddess of death and sent to serve in her army in the realm of Helheim.";
                    break;
                default:
                    break;
            }
            return base.ToString() + $"Weapon {EquipedWeapon}\n" +
                $"Race Description: {raceDescription}";
            
        }//end ctor
        public override int CalcDamage()
        {
            return new Random().Next(EquipedWeapon.MinDamage, EquipedWeapon.MaxDamage + 1);

        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquipedWeapon.BonusHitChance;
            //Hitchance - Block = chance that you hit.
            //roll a random number between 1 and 100. if its less than the hit chance we hit.
        }
    }
}
