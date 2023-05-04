using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public sealed class Draugr : Monster
    {
        private bool _isHaunted;

        public bool IsHaunted
        {
            get { return _isHaunted; }
            set { _isHaunted = value; }
        }


        public Draugr(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isHaunted) : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
        {
           
            IsHaunted = isHaunted;

        }
            
       
        public Draugr() 
        {
            Name = "Lesser-Draugr";
            HitChance = 40;
            Block = 30;
            MaxLife = 15;
            MinDamage = 1;
            MaxDamage = 6;
            Description = "Undead creatures that come in various types and have different abilities, this one has yet to mature..";
            IsHaunted = false;
        }

        //override calc()
        //mods
        public override int CalcDamage()
        {
            if (IsHaunted)
            return (base.CalcDamage() + 5);
            else
            {
                return base.CalcDamage();
            }
        }
        public override string ToString()
        {
            if (IsHaunted)
            {
            return base.ToString() + $"Something Evil has possessed this creature making its attacks even stronger.";
            }
            else
            {
                return base.ToString();
            }
            

        }
        //tostring
        //baseToString()











    }
}
