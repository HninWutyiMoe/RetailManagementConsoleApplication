using System;
using System.Collections.Generic;
using System.Linq;
using static RetailManagementConsoleApplication.Program;

namespace RetailManagementConsoleApplication
{
    public static class ManagerMenu
    {
        //case 3 : ManagerMenu() from MainMenu()
        public static void DisplayManagerMenu(List<Product> product, decimal totalRevenue, decimal totalProfit)
        {
            Console.WriteLine("\nMANAGER MENU");
            Console.WriteLine("Sales Report : ");
            Console.WriteLine("Id\tName\tQty\tSellingPrice\tProfit");

            foreach (var p in product) 
            {
                Console.WriteLine($"{p.productId}\t{p.productName}\t{p.quantitySold}\t{p.sellingPrice:C}\t{p.quantitySold * p.profitPerItem:C}");
            }

            Console.WriteLine($"\nTotal Revenue : {totalRevenue:C}");
            Console.WriteLine($"Total Profit : {totalProfit:C}");
        }
}
}
