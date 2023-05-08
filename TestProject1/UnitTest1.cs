using Xunit;
using DungeonLibrary;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestCalcDamage()
        {

            Ancient test = new Ancient("Ancient Gaurdian", 55, 30, 25, 1, 6, "Ancient robotic beings that possess powerful elemental attacks.", true);
            int minDamage = 1, maxDamage = 6;
            //int actual = test.CalcDamage(minDamage);



        }
    }
    
}