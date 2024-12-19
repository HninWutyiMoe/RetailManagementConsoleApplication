using System;
using System.Collections.Generic;
namespace RetailManagementConsoleApplication
{
        //Product class to represent inventory items
        public class Product
        {
            public int productId { get; set; }
            public required string productName { get; set; }
            public int Stock { get; set; }
            public decimal sellingPrice { get; set; }
            public decimal profitPerItem { get; set; }
            public int quantitySold { get; set; } 
        }
}
