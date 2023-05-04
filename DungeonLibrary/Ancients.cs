using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Ancient : Monster
    {
        private bool _isAggressive;

        public bool IsAggressive
        {
            get { return _isAggressive; }
            set { _isAggressive = value; }
        }

        public Ancient(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isAggressive) : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
            IsAggressive = isAggressive;
        }

        public Ancient()
        {
            Name = "Young Ancient";
            HitChance = 50;
            Block = 25;
            MaxLife = 15;
            MinDamage = 1;
            MaxDamage = 5;
            Description = "Ancient robotic beings that possess powerful elemental attacks, this one hasn't quite accessed its full potential ";
            IsAggressive = false;
        }

        //override calc()
        //mods
        public override int CalcDamage()
        {
            if (IsAggressive)
                return (base.CalcDamage() + 5);
            else
            {
                return base.CalcDamage();
            }
        }
        public override string ToString()
        {
            if (IsAggressive)
            {
                return base.ToString() + $"This ancient is extremely bitter from all the past years of being alive, making it extremely aggressive with an increased attack.";
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
