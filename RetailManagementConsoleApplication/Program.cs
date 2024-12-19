using System;
using System.Collections.Generic;

namespace RetailManagementConsoleApplication
{
    class Program
    {
        //Create inventory list
        static List<Product> product = new List<Product>();
        static decimal totalRevenue = 0;
        static decimal totalProfit = 0;

        static void Main(string[] args)
        {
            AddProduct();
            MainMenu();
        }

        //AddInventory
        static void AddProduct()
        {
            product.Add(new Product{ productId = 1, productName = "Toner", Stock = 30, sellingPrice = 31000, profitPerItem = 10500 });
            product.Add(new Product{ productId = 2, productName = "Serum", Stock = 28, sellingPrice = 21000, profitPerItem = 7000 });
            product.Add(new Product{ productId = 3, productName = "Lotion", Stock = 36, sellingPrice = 35500, profitPerItem = 12300 });
        }

        //MainMenu
        static void MainMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nRetail Management System");
                Console.WriteLine("1. Stock Menu");
                Console.WriteLine("2. Cashier Menu");
                Console.WriteLine("3. Manager Menu");
                Console.WriteLine("4. Exit");
                
                Console.WriteLine("Select an option : ");
                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                       
                        StockMenu.DisplayStockMenu(product);
                        break;

                    case "2":
                        CashierMenu.DisplayCashierMenu(product, ref totalRevenue, ref  totalProfit);
                        break;

                    case "3":
                        ManagerMenu.DisplayManagerMenu(product,totalRevenue,totalProfit);
                        break;

                    case "4":
                        Console.WriteLine("Exiting the system!");
                        return;

                    default:
                        Console.WriteLine("\nInvalid! Please try again. ");
                        break;

                }
            }
        }
    }
}