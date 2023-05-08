using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Revenant : Monster
    {
        private bool _isDemonic;

        public bool IsDemonic
        {
            get { return _isDemonic; }
            set { _isDemonic = value; }
        }
        public Revenant(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isDemonic) : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            IsDemonic = isDemonic;
            
        }
        public Revenant() 
        {
            Name = "Demonic Revenant";
            HitChance = 40;
            Block = 50;
            MaxLife = 15;
            Life = MaxLife;
            MinDamage = 1;
            MaxDamage = 4;
            Description = "Ghost-like enemies that are difficult to hit and can move quickly. The extreme speed weakens the blows but they occur more often. ";
            IsDemonic = true;
        }

        public override int CalcBlock()
        {
            if (IsDemonic)
                return (base.CalcBlock() + 10);
            else
            {
                return base.CalcBlock();
            }
        }
        public override string ToString()
        {
            if (IsDemonic)
            {
                return base.ToString() + $"A Demonic power increases speed and makes it difficult to land an attack. The speed comes with a downside making its attacks weaker.";
            }
            else
            {
                return base.ToString();
            }
        }

    }//end class
}//end name