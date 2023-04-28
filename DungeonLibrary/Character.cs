namespace DungeonLibrary
{
    //abstract marks the class as incomplete it must be inherited somewhere to be used.
    //abstract classes cannot be created as an object using the "new()"
    public abstract class Character//: object
    {
        /*
         

        Character: /*
            Create Fields and Properties for each of the following attributes.         
            life – int
            name – string
            hitChance – int
            block – int
            maxLife – int
            INCLUDE a business rule that Life cannot be more than MaxLife. If it is, set it equal to MaxLife.
        Fully Qualified CTOR

        CalcBlock() – returns the value of block
        CalcHitChance() – returns the value of Hitchance
        CalcDamage() – returns 0
        NicelyFormatted ToString()
         */


        //Fields
        private string _name;
        private int _maxLife;
        private int _life;
        private int _hitChance;
        private int _block;

        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value > MaxLife)
                    _life = MaxLife;
                else _life = value;
            }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }



        //Constructors Life = life -> life = Maxlife
        public Character(string name, int hitChance, int block, int maxLife)
        {
            Name = name;
            MaxLife = maxLife;
            Life = maxLife;
            HitChance = hitChance;
            Block = block;
        }
        public Character()
        {
        }
        public override string ToString()
        {
            return $"---v {Name} v---\n" +
                $"Maximum Life: {MaxLife}\n" +
                $"Current Life: {Life}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}";


        }
        //Methods
       public virtual int CalcBlock() 
        {
            return Block; 
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public abstract int CalcDamage();
        // an abstract will have no functionality, no scopes
        //makes override MANDATORY
        #region Recursion Example

        /*                     ===private static int RecursiveCountdown(int value)===
        *   {
        *       if (value == 0)
        *       {
        *       return value;
        *       }
        *       else
        *       {
        *       Console.WriteLine(value);
        *       return RecursiveCountdown(value - 1);
        *       }
        *   }
        *                   Code Explanation
        *                   The RecursiveCountdown method above will allow a
        *                   positive value to be passed in by the program. As it
        *                   executes, it checks the value and if the value is 0, it simply
        *                   returns 0. However, anything above 0 will result in sharing
        *                   the value to the screen, decrementing the value, and calling
        *                   the method again.
        *                               Recursion happens when a
        *                               method calls upon itself until a
        *                               specific condition is met to
        *                               achieve specific functionality
        */
        #endregion





    }
}