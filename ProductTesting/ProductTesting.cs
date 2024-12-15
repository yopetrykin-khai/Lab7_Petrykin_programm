using Lab7_Petrykin_programm;
using static System.Net.Mime.MediaTypeNames;
namespace Lab_7_Petrykin_testingprogramm
{
    [TestClass]
    public class ProductTesting
    {
        [TestMethod]
        [DataRow(5, 100)]
        [DataRow(10, 0)]
        [DataRow(10, -1)]
        public void Test_Buy_Method_Exceptions(int number, int amountof)
        {
            //Arrange
            Product product = new Product();
            product.NumberOf = number;
            //Act+Assert
            Assert.ThrowsException<Exception>(() => product.Buy(amountof));
        }

        [TestMethod]
        [DataRow(10, 5, 5)]
        public void Test_Buy_Method_CorrectValues(int number, int amountof, int exp_number)
        {
            //Arrange
            Product product = new Product();
            product.NumberOf = number;
            //Act
            product.Buy(amountof);
            double actual = product.NumberOf;
            //Assert
            Assert.AreEqual(exp_number, actual);
        }
        [TestMethod]
        [DataRow(5, 100, true)]
        [DataRow(10, 0, true)]
        [DataRow(10, -1, false)]
        public void Test_OverBuy_Method_Exceptions(int number, int amountof, bool test)
        {
            //Arrange
            Product product = new Product();
            product.NumberOf = number;
            //Act+Assert
            Assert.ThrowsException<Exception>(() => product.Buy(amountof, test));
        }
        [TestMethod]
        [DataRow(5, 3, 2, 100, 80, true)]
        [DataRow(5, 3, 2, 100, 100, false)]
        public void Test_OverBuy_Method_CorrectValues(int number, int amountof, int exp_number, double cost, double exp_cost, bool test)
        {
            //Arrange
            Product product = new Product();
            product.NumberOf = number;
            product.Cost = cost;
            //Act
            product.Buy(amountof, test);
            int actual = product.NumberOf;
            double actual2 = product.Cost;
            //Assert
            Assert.AreEqual(exp_number, actual);
            Assert.AreEqual(exp_cost, actual2, 0.01);
        }
        [TestMethod]
        [DataRow(-2)]
        [DataRow(0)]
        public void Test_Delivery_Method_Exceptions(int test)
        {
            //Arrange
            Product product = new Product();
            //Act+Assert
            Assert.ThrowsException<Exception>(() => product.Delivery(test));
        }
        [TestMethod]
        [DataRow(5, 5, 10)]
        public void Test_Delivery_Method_CorrectValues(int test, int numberof, int exp_numberof)
        {
            //Arrange
            Product product = new Product();
            product.NumberOf = numberof;
            //Act+Assert
            Assert.IsTrue(product.Delivery(test));
            int actual = product.NumberOf;
            Assert.AreEqual(actual, exp_numberof);
        }
        [TestMethod]
        [DataRow("30.11.2024", true)]
        [DataRow("01.09.2024", false)]
        public void Test_Date_ValidityCheck(string s, bool test)
        {
            //Arrange
            Product product = new Product();
            product.Date = "01.11.2024";
            //Act
            bool actual = Product.DateCheck(s);
            //Assert
            Assert.AreEqual(test, actual);
        }
        [TestMethod]
        [DataRow(20, 100, 80)]

        public void Test_Discount_Method_CorrectValue(int discount, double cost, double exp_cost)
        {
            //Arrange
            Product product = new Product();
            product.Cost = cost;
            //Act
            bool test = product.Discount(discount);
            double actual = product.Cost;
            //Assert
            Assert.IsTrue(test);
            Assert.AreEqual(actual, exp_cost);
        }
        [TestMethod]
        [DataRow(-1, 100, 100)]
        [DataRow(101, 100, 100)]
        public void Test_Discount_Method_Exceptions(int discount, double cost, double exp_cost)
        {
            //Arrange
            Product product = new Product();
            product.Cost = cost;
            //Act+Assert
            Assert.ThrowsException<Exception>(() => product.Discount(discount));
            double actual = product.Cost;
            Assert.AreEqual(actual, exp_cost);
        }
        [TestMethod]
        [DataRow("Me;1;5;10;11.11.1111")]
        [DataRow("Meat;10;5;10;11.11.1111")]
        [DataRow("Meat;1;-2;10;11.11.1111")]
        [DataRow("Meat;1;20;-10;11.11.1111")]
        [DataRow("Meat;1;20;10,2;11.11.1111")]
        [DataRow("Meat;1;20;10,2;11.11.2025")]
        [DataRow(";1;20;10,2;11.11.2025")]
        public void Test_Parse_Method_Exceptions(string s)
        {
            //Arrange
            Product product = new Product();
            //Act+Assert
            Assert.ThrowsException<Exception>(() => Product.Parse(s));

        }
        [TestMethod]
        [DataRow("Pepsi;3;50;15;15.10.2024")]

        public void Test_Parse_Method_CorrectValues(string s)
        {
            //Arrange
            Product product = Product.Parse(s);
            //Act

            //Assert
            Assert.AreEqual("Pepsi", product.Name);
            Assert.AreEqual((ProductType)3, product.Type);
            Assert.AreEqual(50, product.Cost);
            Assert.AreEqual(15, product.NumberOf);
            Assert.AreEqual("15.10.2024", product.Date);
        }
        [TestMethod]
        [DataRow(-10)]
        [DataRow(0)]
        public void Test_Cost_Value_Zero_Exception(double cost)
        {
            //Arrange
            Product product = new Product();
            //Act+Assert
            Assert.ThrowsException<Exception>(() => product.Cost = cost);
        }
        [TestMethod]
        public void Test_Cost_Value_CorrectValue()
        {
            //Arrange
            Product product = new Product();
            double cost = 50.50;
            //Act
            product.Cost = cost;
            //Assert
            Assert.AreEqual(product.Cost, cost);
        }
        [TestMethod]
        public void Test_FirstCost_Value_CorrectValue()
        {
            //Arrange
            Product product = new Product();
            double cost = 100;
            //Act
            product.Cost = cost;
            product.Discount(20);
            product.FirstCost();
            double actual = product.Cost;
            //Assert
            Assert.AreEqual(cost, actual);
        }

    }
}