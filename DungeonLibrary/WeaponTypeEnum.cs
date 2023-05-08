using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Weapon will includ WeaponType, so make it public and make it enum.
    //at least 5 types of weapons
    // intent of this is to provide potential expansions, such as 
    public enum WeaponType
    {
        A_Axe,
        B_Daggers,
        C_Bare_Hands,
        D_Valkyrie_Armor,
        E_Bow,
        Naked
    }
}
