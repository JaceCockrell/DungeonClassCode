using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Troll : Monster
    {
        private bool _isClever;
        public bool IsClever
        {
            get { return _isClever; }
            set { _isClever = value; }
        }
        public Troll(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isClever) : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            IsClever = isClever;

        }
        public Troll()
        {
            Name = "Sleepy Troll";
            HitChance = 25;
            Block = 10;
            MaxLife = 12;
            MinDamage = 1;
            MaxDamage = 3;
            Description = "Large, powerful enemies that can deal heavy damage and require different strategies to defeat.";
            IsClever = false;
        }
        public override int CalcBlock()
        {
            if (IsClever)
            {
                return base.CalcBlock() + 5;
            }
            else
            {
                return base.CalcBlock();
            }
        }
        public override string ToString()
        {
            if (!IsClever)
            {
                return base.ToString() + $"Sleepy and lethargic, everything about this powerful creature has almost been nerfed.";
            }
            else
            {
                return base.ToString();
            }
        }
    }
    
}
