using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;
        private int _maxDamage;
        private string _description;
        //^Fields
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value < MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        // ^props
        
        
        //maxdam int
        //string description
        public Monster(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife)
        {
            if (maxDamage <= minDamage || minDamage <= 0)
            {
                throw new ArgumentException("Min Damage must be between zero and Max Damage");
            }

            Description = description;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            
            
           //create the properties above,                        *|
            ////add parameters to the constructor                      *|
            /////and asign properties inside the constructor. Pascal = Camel

        }
        public Monster() { }
        public override int CalcDamage()
        {
        //TODO override CalcDamage()
            //return a random number between the MaxDamage property and the MinDamage property
            return new Random().Next(MinDamage, MaxDamage + 1);
        }
        public override string ToString()
        {
            return //$"Name: {Name}\n" +
                base.ToString() + $"Description: {Description}\n" +
                $"Maximum Damage: {MaxDamage}\n" +
                $"Minimum Damage: {MinDamage}\n";
               // $"Hit-Chance: {HitChance}\n" +
               // $"Block: {Block}\n" +
               // $"Max Life {MaxLife}";
            //to write cw tab (m1)
        }

         // Override the ToString() to include custom props
    }
}
