using Lab7_Petrykin_programm;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Security.Principal;
using System.Threading.Channels;
using System.Xml.Linq;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Program
{
    public static void Main()
    {
        bool CheckTheException = false;
        do
        {
            try
            {
                Console.WriteLine("The number of products");
                int number = int.Parse(Console.ReadLine());
                if (number < 1) throw new Exception("Amount of products should be more than zero!");
                Console.WriteLine($"Amount of products:{number}");
                Product.MaxProducts = number;
                List<Product> products = new List<Product>(number);
                int choose = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Chose ur next step:");
                        Console.WriteLine("1 - Add an object");
                        Console.WriteLine("2 - Show all the objects");
                        Console.WriteLine("3 - Find an object");
                        Console.WriteLine("4 - Delete an object");
                        Console.WriteLine("5 - Demonstration");
                        Console.WriteLine("6 - Demonstration of static method");
                        Console.WriteLine("7 - Save collection into file");
                        Console.WriteLine("8 - Read collection from file");
                        Console.WriteLine("9 - Clear the collection");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("Chose ur next step:");
                        choose = int.Parse(Console.ReadLine());
                        switch (choose)
                        {
                            case 1:
                                if (Product.Numberofcreated == Product.MaxProducts)
                                {
                                    throw new Exception("You can`t add more items");
                                }
                                Console.WriteLine("How to add an element?\n 1-Constructor\n2-Constructor\n3-Constructor\n4-Constuctor(string)");
                                do
                                {
                                    try
                                    {
                                        int choose1 = int.Parse(Console.ReadLine());
                                        switch (choose1)
                                        {
                                            case 1:
                                                Product product;
                                                try
                                                {
                                                    product = new Product();
                                                    products.Add(product);
                                                }
                                                catch (OverflowException e) { Console.WriteLine(e.Message); CheckTheException = true; break; }
                                                Console.WriteLine("Product created");
                                                CheckTheException = true;
                                                break;

                                            case 2:

                                                string name = "";
                                                ProductType check = ProductType.Else;

                                                product = new Product();
                                                do
                                                {
                                                    try
                                                    {
                                                        name = Name();
                                                        product.Name = name;
                                                        CheckTheException = true;
                                                    }
                                                    catch (OverflowException e) { Console.WriteLine(e.Message); CheckTheException = true; break; }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = false;
                                                do
                                                {
                                                    try
                                                    {
                                                        check = (ProductType)Type();
                                                        product.Type = check;
                                                        CheckTheException = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = false;
                                                try
                                                {
                                                    product = new Product(name, check);
                                                    CheckTheException = true;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                products.Add(product);
                                                Console.WriteLine("Product created");
                                                break;
                                            case 3:
                                                name = "";
                                                check = ProductType.Else;
                                                double cost = 0;
                                                string date = "";
                                                int amount = 0;
                                                product = new Product();
                                                do
                                                {
                                                    try
                                                    {
                                                        name = Name();
                                                        product.Name = name;
                                                        CheckTheException = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = false;

                                                do
                                                {
                                                    try
                                                    {
                                                        check = (ProductType)Type();
                                                        product.Type = check;
                                                        CheckTheException = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = false;

                                                do
                                                {
                                                    try
                                                    {
                                                        cost = Cost();
                                                        product.Cost = cost;
                                                        CheckTheException = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = false;

                                                do
                                                {
                                                    try
                                                    {
                                                        date = Date();
                                                        product.Date = date;
                                                        CheckTheException = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = false;

                                                do
                                                {
                                                    try
                                                    {
                                                        amount = Amount();
                                                        product.NumberOf = amount;
                                                        CheckTheException = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.Message);
                                                    }
                                                }
                                                while (!CheckTheException);

                                                try
                                                {
                                                    product = new Product(name, check, cost, amount, date);
                                                    Console.WriteLine("Product created");
                                                    products.Add(product);
                                                    CheckTheException = true;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                break;
                                            case 4:

                                                product = new Product();
                                                Console.WriteLine("1 - Meat");
                                                Console.WriteLine("2 - Milk");
                                                Console.WriteLine("3 - Drink");
                                                Console.WriteLine("4 - Bread");
                                                Console.WriteLine("5 - Else");
                                                Console.WriteLine("Create your product (Name;Type(1-5);Cost;Amount of product;Date(dd.mm.yyyy))");
                                                do
                                                {
                                                    string s = Console.ReadLine();
                                                    if (Product.TryParse(s, out Product p))
                                                    {
                                                        product = p;
                                                        Console.WriteLine("Product created");
                                                        products.Add(product);
                                                        CheckTheException = true;
                                                    }
                                                }
                                                while (!CheckTheException);
                                                CheckTheException = true;
                                                break;
                                            default:
                                                throw new Exception("Wrong number!");
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Wrong format");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                while (!CheckTheException);
                                CheckTheException = false;
                                break;
                            case 2:
                                Output(products);
                                break;
                            case 3:
                                Find(products);
                                break;
                            case 4:
                                Delete(products);
                                break;
                            case 5:
                                Demonstration(products);
                                break;
                            case 6:
                                Demonstration2(products);
                                break;
                            case 7:
                                Console.WriteLine("1 - Save into .csv");
                                Console.WriteLine("2 - Save into .json");
                                try
                                {
                                    while (!CheckTheException)
                                    {
                                        int check = int.Parse(Console.ReadLine());
                                        switch (check)
                                        {
                                            case 1:
                                                Console.WriteLine("Input your path: ");
                                                string s = Console.ReadLine();
                                                if (!System.String.IsNullOrEmpty(s))
                                                    SaveToFileCSV(products, s);
                                                //C:\УЧЕБА ДЗ\DZ\Lab DZ\2 курс\ООП\Lab_7\checkcsv.csv
                                                CheckTheException = true;
                                                break;
                                            case 2:
                                                Console.WriteLine("Input your path: ");
                                                s = Console.ReadLine();
                                                if (!System.String.IsNullOrEmpty(s))
                                                    SaveToFileJson(products, s);
                                                //C:\УЧЕБА ДЗ\DZ\Lab DZ\2 курс\ООП\Lab_7\checkjson.json
                                                CheckTheException = true;
                                                break;
                                            default:
                                                throw new Exception("Wrong format");
                                        }
                                    }
                                    CheckTheException = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Wrong format");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case 8:
                                Console.WriteLine("1 - Read from .csv");
                                Console.WriteLine("2 - Read from .json");
                                try
                                {
                                    while (!CheckTheException)
                                    {
                                        int check = int.Parse(Console.ReadLine());
                                        switch (check)
                                        {
                                            case 1:
                                                Console.WriteLine("Input your path: ");
                                                string s = Console.ReadLine();
                                                if (!System.String.IsNullOrEmpty(s))
                                                {
                                                    List<Product> read_account = ReadFromFileCSV(s);
                                                    Console.WriteLine("Account Objects:\n");
                                                    foreach (Product product in read_account)
                                                    {
                                                        Console.WriteLine(product.ToString());
                                                        products.Add(product);
                                                    }
                                                }
                                                //C:\УЧЕБА ДЗ\DZ\Lab DZ\2 курс\ООП\Lab_7\testcsv.csv
                                                CheckTheException = true;
                                                break;
                                            case 2:
                                                Console.WriteLine("Input your path: ");
                                                s = Console.ReadLine();

                                                if (!System.String.IsNullOrEmpty(s))
                                                {
                                                    List<Product> read_account = ReadFromFileJson(s);
                                                    Console.WriteLine("Account Objects:\n");
                                                    if (read_account != null)
                                                    {
                                                        foreach (Product product in read_account)
                                                        {
                                                            Console.WriteLine(product.ToString());
                                                            products.Add(product);
                                                        }
                                                    }
                                                    else
                                                        Console.WriteLine("Error by reading JSON file");
                                                }
                                                //C:\УЧЕБА ДЗ\DZ\Lab DZ\2 курс\ООП\Lab_7\testjson.json
                                                CheckTheException = true;

                                                break;
                                            default:
                                                throw new Exception("Wrong format");
                                        }
                                    }
                                    CheckTheException = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Wrong format");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case 9:
                                products.Clear();
                                Product.Numberofcreated = 0;
                                break;
                            case 0:
                                CheckTheException = true;
                                break;
                            default:
                                throw new Exception("Wrong format");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong format");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (!CheckTheException);
                CheckTheException = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (!CheckTheException);
        int DiscountCheck(int discount)
        {
            if (discount > 0 && discount < 100)
                return discount;
            else return 0;
        }
        string Name()
        {
            Console.WriteLine("Input name of the product: ");
            string check1 = Console.ReadLine();
            return check1;
        }

        int Type()
        {
            Console.WriteLine("What type should your product be?");
            Console.WriteLine("1 - Meat");
            Console.WriteLine("2 - Milk");
            Console.WriteLine("3 - Drink");
            Console.WriteLine("4 - Bread");
            Console.WriteLine("5 - Else");
            Console.WriteLine("Input type of the product:");
            int check2 = int.Parse(Console.ReadLine());
            return check2;
        }

        double Cost()
        {
            Console.WriteLine("Input cost of the product:");
            double check3 = double.Parse(Console.ReadLine());
            return check3;
        }

        string Date()
        {
            Console.WriteLine("Input the date of the product: (dd.MM.yyyy)");
            string inputDate = Console.ReadLine();
            return inputDate;
        }

        int Amount()
        {
            Console.WriteLine("Input amount of the product: ");
            int check5 = int.Parse(Console.ReadLine());
            return check5;
        }

        void SaveToFileCSV(List<Product> product, string path)
        {
            List<string> lines = new List<string>();
            foreach (Product p in product)
            {
                lines.Add(p.ToString());
            }
            try
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine($"Check out the CSV file at:{Path.GetFullPath(path)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        List<Product> ReadFromFileCSV(string path)
        {
            List<Product> products = new List<Product>();
            try
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(path).ToList();
                foreach (string line in lines)
                {
                    bool result = Product.TryParse(line, out Product? product);
                    if (result) products.Add(product);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Reading file error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return products;
        }

        void SaveToFileJson(List<Product> products, string path)
        {
            try
            {
                string jsonstring = "";
                foreach (Product p in products)
                {
                    jsonstring += JsonConvert.SerializeObject(p);
                    jsonstring += "\n";
                }
                File.WriteAllText(path, jsonstring);
                Console.WriteLine($"Check out the JSON file here: {Path.GetFullPath(path)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        List<Product> ReadFromFileJson(string path)
        {
            bool Catch = false;
            List<Product> products = null;

            try
            {
                string text = File.ReadAllText(path);
                products = JsonConvert.DeserializeObject<List<Product>>(text);
                Catch = true;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Reading file error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return products;
        }

        void Demonstration(List<Product> products)
        {
            bool CheckTheException = false;
            List<Product> result = new List<Product>();

            do
            {
                try
                {
                    Console.WriteLine("What do you want to do? (1-Buy/delivery product 2-Set a discount on a product 3-Demonstration)");
                    int resh = int.Parse(Console.ReadLine());
                    switch (resh)
                    {
                        case 1:
                            do
                            {
                                try
                                {
                                    int choose = 0;
                                    Console.WriteLine("1-Buy product. 2-Delivery product");
                                    choose = int.Parse(Console.ReadLine());
                                    if (choose != 1 && choose != 2)
                                    {
                                        throw new Exception("Wrong number!");
                                    }
                                    switch (choose)
                                    {
                                        case 1:
                                            result = products.FindAll(s => s.NumberOf > 0);
                                            if (result.Count == 0) { Console.WriteLine("You have no items to sell!"); break; }
                                            do
                                            {
                                                try
                                                {
                                                    Output(products);
                                                    Console.WriteLine("What product do you want to buy?");
                                                    int buy = int.Parse(Console.ReadLine());
                                                    if (buy < 1 || buy > products.Count)
                                                    {
                                                        throw new Exception("There is no such number!");
                                                    }
                                                    if (products[buy - 1] == null)
                                                    {
                                                        throw new Exception("No product with such number!");
                                                    }
                                                    do
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("How many do you want to buy?");
                                                            int amount = int.Parse(Console.ReadLine());
                                                            if (products[buy - 1].Buy(amount))
                                                            {
                                                                Console.WriteLine("Product bought");
                                                                CheckTheException = true;
                                                            }
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine("Wrong format");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                    }
                                                    while (!CheckTheException);
                                                    CheckTheException = true;
                                                    break;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }

                                            }
                                            while (!CheckTheException);
                                            CheckTheException = true;
                                            break;
                                        case 2:
                                            result = products.FindAll(s => s.NumberOf > 0);
                                            if (result.Count == 0) { Console.WriteLine("You have no items to sell!"); break; }
                                            do
                                            {
                                                try
                                                {
                                                    Output(products);
                                                    Console.WriteLine("What product do you want to delivery?");
                                                    int sell = int.Parse(Console.ReadLine());
                                                    if (sell < 1 || sell > products.Count)
                                                    {
                                                        throw new Exception("There is no such number!");
                                                    }
                                                    if (products[sell - 1] == null)
                                                    {
                                                        throw new Exception("No product with such number!");
                                                    }
                                                    do
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("How many do you want to delivery?");
                                                            int amount = int.Parse(Console.ReadLine());
                                                            if (products[sell - 1].Delivery(amount))
                                                            {
                                                                Console.WriteLine("Product delievered");
                                                                CheckTheException = true;
                                                            }
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine("Wrong format");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                    }
                                                    while (!CheckTheException);
                                                    CheckTheException = true;
                                                    break;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }

                                            }
                                            while (!CheckTheException);
                                            CheckTheException = true;
                                            break;
                                        default: throw new Exception("Wrong type!");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Wrong format");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            while (!CheckTheException);
                            CheckTheException = true;
                            break;
                        case 2:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Do you want to set (1), remove (2) or show (3) a discount?");
                                    int choose = int.Parse(Console.ReadLine());
                                    switch (choose)
                                    {

                                        case 1:
                                            do
                                            {
                                                try
                                                {
                                                    Output(products);
                                                    Console.WriteLine("What product you want to set a discount on?");
                                                    int discount = int.Parse(Console.ReadLine());
                                                    if (discount < 1 || discount > products.Count)
                                                    {
                                                        throw new Exception("There is no such number!");
                                                    }
                                                    if (products[discount - 1] == null)
                                                    {
                                                        throw new Exception("No product with such number!");
                                                    }
                                                    do
                                                    {
                                                        try
                                                        {
                                                            Program program = new Program();

                                                            Console.WriteLine("What discount you want to set? %");
                                                            int setdiscount = int.Parse(Console.ReadLine());
                                                            if (DiscountCheck(setdiscount) != 0)
                                                                products[discount - 1].Discount(setdiscount);
                                                            else throw new Exception("Discount can`t be less than zero and above hundred!");
                                                            Console.WriteLine("Discount set!");
                                                            CheckTheException = true;
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine("Wrong format");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine(ex.Message);
                                                        }
                                                    }
                                                    while (!CheckTheException);
                                                    CheckTheException = true;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }
                                            }
                                            while (!CheckTheException);
                                            CheckTheException = true;
                                            break;
                                        case 2:
                                            do
                                            {
                                                try
                                                {
                                                    Output(products);
                                                    Console.WriteLine("What products discount you want to remove?");
                                                    int removediscount = int.Parse(Console.ReadLine());
                                                    if (removediscount < 1 || removediscount > products.Count)
                                                    {
                                                        throw new Exception("There is no such number!");
                                                    }
                                                    if (products[removediscount - 1] == null)
                                                    {
                                                        throw new Exception("No product with such number!");
                                                    }
                                                    products[removediscount - 1].FirstCost();
                                                    Console.WriteLine("Discount removed!");
                                                    CheckTheException = true;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }
                                            }
                                            while (!CheckTheException);
                                            CheckTheException = true;
                                            break;
                                        case 3:
                                            do
                                            {
                                                try
                                                {
                                                    Output(products);
                                                    Console.WriteLine("What products discount you want to see?");
                                                    int i = int.Parse(Console.ReadLine());
                                                    if (i < 1 || i > products.Count)
                                                    {
                                                        throw new Exception("There is no such number!");
                                                    }
                                                    if (products[i - 1] == null)
                                                    {
                                                        throw new Exception("No product with such number!");
                                                    }
                                                    Console.WriteLine($"Discount Percentage: {products[i - 1].DiscountPercentage}%");
                                                    CheckTheException = true;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Wrong format");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }
                                            }
                                            while (!CheckTheException);
                                            CheckTheException = true;
                                            break;
                                        default: throw new Exception("Wrong number!");
                                    }

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Wrong format");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            while (!CheckTheException);
                            CheckTheException = true;
                            break;
                        case 3:
                            bool check25 = false;
                            result = products.FindAll(s => s.NumberOf > 0);
                            if (result.Count == 0) { Console.WriteLine("You have no items to sell!"); break; }
                            do
                            {
                                try
                                {
                                    Output(products);
                                    Console.WriteLine("What product do you want to buy with discount?");
                                    int buy = int.Parse(Console.ReadLine());
                                    if (buy < 1 || buy > products.Count)
                                    {
                                        throw new Exception("There is no such number!");
                                    }
                                    if (products[buy - 1] == null)
                                    {
                                        throw new Exception("No product with such number!");
                                    }
                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("How many do you want to buy?");
                                            int amount = int.Parse(Console.ReadLine());
                                            if (products[buy - 1].Buy(amount, true))
                                            {
                                                Console.WriteLine($"Applied {products[buy - 1].DiscountPercentage:f2}% discount. New price: {products[buy - 1].Cost:f2}");
                                                Console.WriteLine("Product bought");
                                                CheckTheException = true;
                                            }

                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Wrong format");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    while (!CheckTheException);
                                    CheckTheException = true;
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Wrong format");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                            }
                            while (!CheckTheException);
                            CheckTheException = true;
                            break;

                        default:
                            throw new Exception("Wrong number!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!CheckTheException);
            CheckTheException = false;

        }
        void Output(List<Product> products)
        {
            int numberofcreated = Product.Numberofcreated;
            CheckTheException = false;
            do
            {
                Console.WriteLine("Number of products created: " + numberofcreated);
                foreach (Product product in products)
                {
                    product.Deconstruct(out string name, out ProductType type, out double cost, out string date, out bool consist, out int numberof);
                    Console.WriteLine($"{products.IndexOf(product) + 1}.Name: {name}\n " +
                        $"Type: {type}\n " +
                        $"Price: {cost}\n " +
                        $"Date: {date}\n " +
                        $"Availability: {(consist ? "Available" : "Not available")}\n " +
                        $"Number of products: {numberof}\n");
                }
                if (products == null || products.Count == 0) { Console.WriteLine("No objects!"); }
                CheckTheException = true;
            }
            while (!CheckTheException);
            CheckTheException = false;
        }
        void Demonstration2(List<Product> products)
        {
            Product product;
            CheckTheException = false;
            bool ifnull = true;
            try
            {
                if (products.Count == 0)
                {
                    throw new Exception("No objects!");
                }
                Console.WriteLine("How many days must pass from the date of production for a product to be considered fresh?");
                do
                {
                    try
                    {
                        int days = int.Parse(Console.ReadLine());
                        Product.NumberofDays = days;
                        CheckTheException = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong format");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!CheckTheException);
                CheckTheException = false;

                Output(products);
                do
                {
                    try
                    {
                        Console.WriteLine("What product`s date you want to check?");
                        int number = int.Parse(Console.ReadLine());
                        if (products[number - 1] == null)
                        {
                            throw new Exception("No object with this number!");
                        }
                        if (number > products.Count || number < 1)
                        {
                            throw new Exception("No object with this number!");
                        }
                        if (Product.DateCheck(products[number - 1].Date))
                        {
                            Console.WriteLine("Fresh product!");
                            CheckTheException = true;
                        }
                        else
                        {
                            Console.WriteLine("Expired");
                            CheckTheException = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong format");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!CheckTheException);
                CheckTheException = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void Find(List<Product> products)
        {
            int check = 0;
            if (products.Count > 0)
            {
                bool CatchTheException = false;
                int number;
                do
                {
                    try
                    {
                        Console.WriteLine("What to look for: (1 - availability, 2 - type)");
                        number = int.Parse(Console.ReadLine());
                        switch (number)
                        {
                            case 1:
                                do
                                {
                                    try
                                    {
                                        bool typeif = false;
                                        Console.WriteLine("Chose what you are interested in (1 - available, 2 - not available)");
                                        int type = int.Parse(Console.ReadLine());

                                        List<Product> result = new List<Product>();
                                        switch (type)
                                        {
                                            case 1: result = products.FindAll(s => s.Consist == true); CatchTheException = true; break;
                                            case 2: result = products.FindAll(s => s.Consist == false); CatchTheException = true; break;
                                            default: throw new Exception("Wrong number!");
                                        }
                                        foreach (var product in result)
                                        {
                                            Console.WriteLine(product.Name);
                                        }
                                        if (result.Count == 0) Console.WriteLine("Objects not found!");
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Wrong format");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                while (!CatchTheException);
                                break;
                            case 2:
                                Console.WriteLine("What type should your product be?");
                                Console.WriteLine("1 - Meat");
                                Console.WriteLine("2 - Milk");
                                Console.WriteLine("3 - Drink");
                                Console.WriteLine("4 - Bread");
                                Console.WriteLine("5 - Else");
                                do
                                {
                                    try
                                    {
                                        bool typeif = false;
                                        int type1 = int.Parse(Console.ReadLine());
                                        if (type1 <= 1 && type1 >= 5) { throw new Exception("Wrong type!"); }
                                        CatchTheException = true;
                                        List<Product> result = new List<Product>();
                                        result = products.FindAll(s => s.Type == (ProductType)type1);
                                        foreach (var product in result)
                                        {
                                            Console.WriteLine(product.Name);
                                        }
                                        if (result.Count == 0) Console.WriteLine("Objects not found!");
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Wrong format");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                while (!CatchTheException);
                                break;
                            default: Console.WriteLine("Wrong number!"); break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong format");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!CatchTheException);
            }
            else { Console.WriteLine("No objects!"); }
        }
        void Delete(List<Product> products)
        {
            if (products.Count > 0)
            {
                bool CheckTheException = false;
                do
                {
                    try
                    {
                        Console.WriteLine("What to look for: (1 - number, 2 - name)");
                        int number = int.Parse(Console.ReadLine());
                        switch (number)
                        {
                            case 1:
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("What number do you want to delete?");
                                        int choose = int.Parse(Console.ReadLine());
                                        if (choose < 1 || choose > products.Count)
                                        {
                                            throw new Exception("There is no such number!");
                                        }
                                        if (products[choose - 1] == null)
                                        {
                                            throw new Exception("There is no such number");
                                        }
                                        products.RemoveAt(choose - 1);
                                        Console.WriteLine("Object deleted");
                                        Product.Numberofcreated = Product.Numberofcreated - 1;
                                        CheckTheException = true;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Wrong format");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                while (!CheckTheException);
                                CheckTheException = true;
                                break;
                            case 2:
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("What is the name of the product you want to delete?");
                                        string name = Console.ReadLine();
                                        foreach (char c in name)
                                        {
                                            if (char.IsNumber(c))
                                            {
                                                throw new Exception("English letters only!");
                                            }
                                            if (c < 'A' || c > 'z')
                                            {
                                                throw new Exception("English letters only!");
                                            }
                                        }
                                        int check1 = products.RemoveAll(x => x.Name == name); ;
                                        CheckTheException = true;
                                        if (check1 == 0)
                                        {
                                            Console.WriteLine("No objects with this name!");
                                        }
                                        else
                                        {
                                            Product.Numberofcreated = Product.Numberofcreated - check1;
                                            Console.WriteLine("Object deleted");
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Wrong format");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                while (!CheckTheException);
                                CheckTheException = true;
                                break;
                            default:
                                throw new Exception("Wrong type!");
                        }
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong format");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    CheckTheException = true;
                }
                while (!CheckTheException);
            }
            else { Console.WriteLine("No objects to delete!"); }
        }
    }
    public int DiscountCheck(int discount)
    {
        if (discount > 0 && discount < 100)
            return discount;
        else return 0;
    }
}