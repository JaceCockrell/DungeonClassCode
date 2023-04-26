using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        /*
         Weapon: Make fields and props for each of these with the appropriate naming conventions.
            Business rule on MinDamage, can't be more than MaxDamage, or less than 1. If it is, default it to 1.
            minDamage – int
            maxDamage – int
            name – string
            bonusHitChance – int
            isTwoHanded - bool
      
         */



        //Fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;


        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value < 1)
                    _minDamage = 1;
                else if (value > MaxDamage)
                    _minDamage = MaxDamage;
                else

                    _minDamage = value;
            }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        //Constructors
        //Fully Qualified ctor - accepts parameters for each of the objects properties.
        public Weapon(string name, int maxDamage, int minDamage, int bonusHitChance, bool isTwoHanded)
        {
            //Assignment 
            //properties = parameter
            //PascalCase = camelCase
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            
           
            
        }//fullyqualified
        public Weapon() 
        {
        }//unqualified

        //Methods
        public override string ToString()
        {
            return $"Weapon: {Name}\n" +
                $"Maximum Damage: {MaxDamage}\n" +
                $"Minimum Damage: {MinDamage}\n" +
                $"Bonus Hits Chance: {BonusHitChance}\n" +
                $"Two-Handed: {IsTwoHanded} ";
        }



    }//weapon class
}//namespace

