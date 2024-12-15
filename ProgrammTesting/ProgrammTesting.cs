using Lab7_Petrykin_programm;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static System.Net.Mime.MediaTypeNames;
namespace ProgrammTesting
{
    [TestClass]
    public class ProgrammTesting
    {
        [TestMethod]
        [DataRow(-2, 0)]
        [DataRow(10, 10)]
        [DataRow(100, 0)]
        public void Test_Discount_Method(int number, int check)
        {
            //Arrange
            Program program = new Program();
            //Act    
            int actual = program.DiscountCheck(number);
            //Assert
            Assert.AreEqual(actual, check);
        }
    }
}
