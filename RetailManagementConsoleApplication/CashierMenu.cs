using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static RetailManagementConsoleApplication.Program;

namespace RetailManagementConsoleApplication
{
    public static class CashierMenu
    {
        //case 2 : CashierMenu() from MainMenu()
        public static void DisplayCashierMenu(List<Product> product, ref decimal totalRevenue, ref decimal totalProfit)
        {
            List<(Product, int)> cart = new List<(Product, int)>();
            decimal totalCost = 0;

            while (true)
            {
                Console.WriteLine("\nCASHIER MENU");
                Console.WriteLine("1. Add Product to Cart");
                Console.WriteLine("2. View Cart and Checkout");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine("Select an option : ");
                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        AddProductToCart(product, cart, ref totalCost);
                        break;

                    case "2":
                        CheckoutCart(cart, ref totalCost,ref totalRevenue,ref totalProfit);
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice! Please try again.");
                        break;
                }

            }
        }

        //Case 1 : from CashierMenu()
        private static void AddProductToCart(List<Product> product, List<(Product, int)> cart, ref decimal totalCost)
        {
            bool addAgain = true;
            while (addAgain) {
                Console.WriteLine("Enter Product Id : ");
                int id = int.Parse(Console.ReadLine());

                var p = product.FirstOrDefault(p => p.productId == id);

                if (p != null)
                {
                    Console.Write("Enter Quantity : ");
                    int quantity = int.Parse(Console.ReadLine());


                        if (quantity <= p.Stock)
                        {

                        Console.Write("\nDo you want to add more products? (yes/no) : ");
                        
                        if (Console.ReadLine().ToLower() == "y")
                        
                        {
                            cart.Add((p, quantity));
                            totalCost += p.sellingPrice * quantity;
                            Console.WriteLine($"\nProduct '{p.productName}' added to cart!");
                        } else
                        {
                            cart.Add((p, quantity));
                            totalCost += p.sellingPrice * quantity;
                            Console.WriteLine($"\nProduct '{p.productName}' added to cart!");
                            return;
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nInsufficient stock!");
                    }
                }
                else
                {
                    Console.WriteLine("\nProduct not found.");
                }
   
            }
        }

        // Case 2 :
        private static void CheckoutCart(List<(Product, int)> cart, ref decimal totalCost, ref decimal totalRevenue,ref decimal totalProfit)
        {
            Console.WriteLine("\nCart Summary : ");
            foreach (var (item, qty) in cart)
            {
                Console.WriteLine($"*{item.productName} => {qty} * {item.sellingPrice:C} = {qty * item.sellingPrice:C}");
            }

            Console.WriteLine($"Total Cost : {totalCost:C}");

            Console.Write("\nConfirm Checkout ? (yes/no) : ");

            if (Console.ReadLine().ToLower() == "y")
            {
                foreach (var (item, qty) in cart)
                {
                    item.Stock -= qty;
                    item.quantitySold += qty;
                    totalRevenue += item.sellingPrice * qty;
                    totalProfit += item.profitPerItem * qty;
                }
                cart.Clear();
                totalCost = 0;
                Console.WriteLine("\nCheckout completed!");
            }
            else
            {
                cart.Clear();
                totalCost = 0;
                Console.WriteLine("\nCheckout completed!");
            }
        }
    }
}
