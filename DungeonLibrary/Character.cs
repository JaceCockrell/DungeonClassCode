namespace DungeonLibrary
{
    public class Character
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
        public Character(string name, int maxLife, int life, int hitChance, int block)
        {
            Name = name;
            MaxLife = maxLife;
            Life = life;
            HitChance = hitChance;
            Block = block;
        }
        public Character()
        {
        }
        public override string ToString()
        {
            return $"{Name}\n" +
                $"Maximum Life: {MaxLife}\n" +
                $"Current Life: {Life}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}";


        }
        //Methods
       public int CalcBlock() 
        {
            return Block; 
        }
        public int CalcHitChance()
        {
            return HitChance;
        }
        public int CalcDamage()
        {
            return 0;
        }

        


    }
}