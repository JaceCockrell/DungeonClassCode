using Xunit;
using DungeonLibrary;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestCalcDamage()
        {
            Weapon w1 = new Weapon("Atreus' Compact bow", 1, 10, 0, true, WeaponType.E_Bow);
            Player test = new Player($"Atreus", 80, 20, 100, Race.B_Giants, w1);
            int actual = test.CalcDamage();
            bool result = (actual >= 0 && actual <= 10);
            Assert.True(result);



        }
        [Fact]
        public void TestBlock()
        {
            Weapon w1 = new("Leviathan Axe", 6, 10, 12, true, WeaponType.A_Axe);
            Player test = new Player($"Atreus", 80, 20, 100, Race.B_Giants, w1);
            int actual = test.CalcBlock();
            Assert.Equal((100-80), actual);
            



        }
    }
    
}