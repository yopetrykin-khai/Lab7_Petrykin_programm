using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Lab7_Petrykin_programm;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Lab7_Petrykin_programm
{
    public class Product
    {
        private string _name = "";
        private double _currentDiscount = 0;
        private string _date = "dd.MM.yyyy";
        private ProductType _type;
        private double _cost = 0;
        private double _firstCost;
        private bool _consist;
        private int _numberof;
        private static int _amountofdays = 31;
        private static int _numberofcreated = 0;
        private static int _maxProducts = 100;
        [Newtonsoft.Json.JsonIgnore]

        public static int MaxProducts
        {
            get => _maxProducts;
            set
            {
                if (_numberofcreated > 0)
                    throw new InvalidOperationException("You can`t change this number after creating a product");
                if (value <= 0)
                    throw new ArgumentException("Maximum amount should be more than zero");
                _maxProducts = value;
            }
        }
        [Newtonsoft.Json.JsonIgnore]

        public static int Numberofcreated
        {
            get { return _numberofcreated; }
            set
            {
                _numberofcreated = value;
            }
        }
        [Newtonsoft.Json.JsonIgnore]
        public static int NumberofDays
        {
            get
            {
                return _amountofdays;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception($"The number can`t be less than zero!{value}");
                }
                _amountofdays = value;
            }
        }
        public Product() : this("Pepsi", (ProductType)3, 50, 15, "15.10.2024")
        {
        }
        public Product(string name, ProductType type) : this(name, type, 25, 10, "20.10.2024")
        {

        }
        public Product(string name, ProductType type, double cost, int numberof, string date)
        {
            if (_numberofcreated >= _maxProducts)
                throw new OverflowException("You can`t add more items");
            Name = name;
            Type = type;
            Cost = cost;
            NumberOf = numberof;
            Date = date;
            _numberofcreated++;
        }

        public void Deconstruct(out string name, out ProductType type, out double cost, out string date, out bool consist, out int numberof)
        {
            name = Name;
            type = Type;
            cost = Cost;
            date = Date;
            consist = Consist;
            numberof = NumberOf;
        }
        [Newtonsoft.Json.JsonIgnore]
        public bool Consist
        { get; private set; } = false;

        public string Name
        {
            get { return _name; }
            set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new Exception($"English letters only!({value})");
                    }
                    if (c < 'A' || c > 'z')
                    {
                        throw new Exception($"English letters only!({value})");
                    }
                }
                if (value.Length < 3)
                {
                    throw new Exception($"Length of the word should be more than 3!({value})");
                }
                _name = value;
            }
        }

        public ProductType Type
        {
            get { return _type; }
            set
            {
                if (Enum.IsDefined(typeof(ProductType), value))
                {
                    _type = value;
                }
                else
                {
                    throw new Exception($"Wrong type! Invalid type value({value}).");
                }
            }
        }
        public double Cost
        {
            get { return _cost; }
            set
            {
                if (value > 0)
                {
                    _cost = value;
                    _firstCost = value;
                }
                else
                {
                    throw new Exception($"Cost must be greater than 0.({value})");
                }
            }
        }
        public int NumberOf
        {
            get { return _numberof; }
            set
            {
                if (value > 0)
                {
                    _numberof = value;
                    Consist = true;
                }

                else if (value == 0)
                {
                    _numberof = value;
                    Consist = false;
                }
                else
                {
                    throw new Exception($"Number of items cannot be negative ({value}).");
                }
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    DateTime currentDate = DateTime.Now;
                    int day = parsedDate.Day;
                    int month = parsedDate.Month;
                    int year = parsedDate.Year;
                    int currentday = currentDate.Day;
                    int currentmonth = currentDate.Month;
                    int currentyear = currentDate.Year;
                    TimeSpan difference = currentDate - parsedDate;
                    if ((year > currentyear) || (year == currentyear && month > currentmonth) || (year == currentyear && month == currentmonth && day > currentday))
                    { throw new Exception($"The product can not be from future!({value})"); }
                    _date = value;
                }
                else
                {
                    throw new Exception($"Invalid date format. Use dd.MM.yyyy.({value})");
                }
            }
        }

        public bool Buy(int amountof)
        {
            if (amountof < 0)
            {
                throw new Exception($"Amount of products: The number can`t be less than zero!({amountof})");
            }
            if (amountof == 0) { throw new Exception($"Amount of products:You can not buy nothing!({amountof})"); }
            if (amountof > _numberof)
            {
                throw new Exception($"Amount of products:No enough products to buy!({amountof})");
            }

            _numberof -= amountof;
            _consist = _numberof > 0;
            return true;
        }
        public bool Buy(int amountof, bool applyDiscount)
        {
            if (amountof < 0)
            {
                throw new Exception($"Amount of products: The number can`t be less than zero!({amountof})");
            }
            if (amountof == 0) { throw new Exception($"Amount of products:You can not buy nothing!({amountof})"); }
            if (amountof > _numberof)
            {
                throw new Exception($"Amount of products:No enough products to buy!({amountof})");
            }
            if (applyDiscount)
            {
                Random r = new Random();
                int rInt = 20;
                Discount(rInt);
            }
            return Buy(amountof);
        }

        public bool Delivery(int amountof)
        {
            if (amountof < 0)
            {
                throw new Exception("The number can`t be less than zero!");
            }
            if (amountof == 0) { throw new Exception("You can not buy nothing!"); }
            if (amountof > 0)
            {
                _numberof += amountof;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Name};{(int)Type};{Cost};{NumberOf};{Date}";
        }

        static public bool DateCheck(string date)
        {
            DateTime date1;
            if (DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
            {
                DateTime currentDate = DateTime.Now;
                TimeSpan difference = currentDate - date1;

                if (difference.Days < NumberofDays)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Discount(int discount)
        {
            if (discount >= 0 && discount <= 100)
            {
                _cost -= _cost / 100 * discount;
                return true;
            }
            throw new Exception("Discount must be between 0 and 100.");
        }
        [Newtonsoft.Json.JsonIgnore]
        public double DiscountPercentage
        {
            get
            {
                if (_firstCost == 0)
                {
                    return 0;
                }
                return ((_firstCost - _cost) / _firstCost) * 100;
            }
        }
        public void FirstCost()
        {
            _cost = _firstCost;
        }
        public static Product Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException();
            }
            string[] words = s.Split(';', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 5) { throw new Exception("Wrong number of parameters"); }
            if (!int.TryParse(words[1], out int type) || !ProductType.TryParse(words[1], out ProductType type11))
            {
                throw new Exception($"Wrong type format!({words[1]})");
            }
            if (!double.TryParse(words[2], out double type1))
            {
                throw new Exception($"Wrong price!({words[2]})");
            }
            if (!int.TryParse(words[3], out int type2))
            {
                throw new Exception($"Wrong amount of product!({words[3]})");
            }
            return new Product(words[0], (ProductType)(int.Parse(words[1])), double.Parse(words[2]), int.Parse(words[3]), words[4]);
        }
        public static bool TryParse(string s, out Product product)
        {
            product = null;
            bool valid = false;
            try
            {
                product = Parse(s);
                valid = true;
            }
            catch (FormatException e) { Console.WriteLine(e.Message); return false; }
            catch (ArgumentNullException) { Console.WriteLine("The string is empty"); return false; }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
            return true;
        }
    }
}

