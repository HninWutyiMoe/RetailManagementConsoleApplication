using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RetailManagementConsoleApplication.Program;

namespace RetailManagementConsoleApplication
{
   public static class StockMenu
    {
        // case 1 : StockMenu from MainMenu
        public static void DisplayStockMenu(List<Product> product)
        {
            while (true)
            {
                Console.WriteLine("\nSTOCK MENU");
                Console.WriteLine("1. Display Stock Items");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Modify Product");
                Console.WriteLine("4. Back to Main Menu");
                Console.WriteLine("Select an option : ");
                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        DisplayStockItems(product);
                        break;

                    case "2":
                        AddProduct(product);
                        break;

                    case "3":
                        ModifyProduct(product);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again");
                        break;
                }
            }

        }

        // case1 : DisplayStockItems() from StockMenu
        private static void DisplayStockItems(List<Product> product)
        {
            Console.WriteLine("\nSTOCK ITEMS : ");
            Console.WriteLine("Id \tName \tStock \tPrice \tProfit/Item");

            foreach (var p in product)
            {
                Console.WriteLine($" {p.productId} \t{p.productName} \t{p.Stock} \t{p.sellingPrice} \t{p.profitPerItem:C}");
            }
        }

        // case2 : AddProduct() from StockMenu
        private static void AddProduct(List<Product> product)
        {
            int newId = product.Last().productId + 1;

            Console.Write("Enter Product Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Quantity: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Price : ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter ProfitPerIeItem : ");
            decimal profit = decimal.Parse(Console.ReadLine());

            product.Add(new Product { productId = newId, productName = name, Stock = stock, sellingPrice = price, profitPerItem = profit });
            Console.WriteLine("\nProduct added successfully!");
        }

        // case3 : ModifyProduct() from StockMenu
        private static void ModifyProduct(List<Product> product)
        {
            Console.WriteLine("\nEnter Product Id to Modify : ");
            int id = int.Parse(Console.ReadLine());
            var p = product.FirstOrDefault(p => p.productId == id);

            if (p != null)
            {
                Console.Write("Enter New Product Name : ");
                var newName= Console.ReadLine();
                if (!string.IsNullOrEmpty(newName)) p.productName = newName;

                Console.Write("Enter New Stock Quantity : ");
            
                var newStock = Console.ReadLine();
                if (!string.IsNullOrEmpty(newStock)) p.Stock = Convert.ToInt32(newStock);

                Console.Write("Enter New Selling Price : ");
                var newPrice = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPrice)) p.sellingPrice = Convert.ToDecimal(newPrice);


                Console.Write("Enter New Profit Per Item : ");
                var newProfit = Console.ReadLine();
                if (!string.IsNullOrEmpty(newProfit)) p.profitPerItem = Convert.ToDecimal(newProfit);

                Console.Write("\nProduct updated successfully!");
            }
            else
            {
                Console.WriteLine("\nProduct not found!");
            }
        }
    }
}
