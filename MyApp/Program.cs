/*
This semester, you will create an eCommerce platform. The application should allow for the management (through CRUD operations) of an inventory (a list of products like the one we have created so-far in class) as well as a user's shopping cart. These are the "hard" requirements of the application:

There must be a menu that allows a person to take the following actions on either the inventory or their shopping cart:
Create an item (or add an item from the inventory to the shopping cart)
Read all items in the inventory or the shopping cart
Update the product details in the inventory (or the number of items in the shopping cart)
Delete the product from the inventory or return all of a product from the shopping cart to the inventory
When a user adds from the inventory to the cart, the number of a product in the inventory and shopping cart must reflect the correct number
A user may not purchase more of a product than is available in the inventory
When a user wants to quit the program, they should check out, which should present a formatted, itemized receipt including the total of their purchase with 7% sales tax included.

*/

using Library.eCommerce.Services;
using Spring2025_Samples.Models;
using System;
using System.Xml.Serialization;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var lastKey = 0;
            Console.WriteLine("Hello. Please Enter a choice from the following options:");
            Console.WriteLine("[C]reate an item (or add an item from the inventory to the shopping cart)");
            Console.WriteLine("[R]ead all items in the inventory or the shopping cart");
            Console.WriteLine("[U]pdate the product details in the inventory (or the number of items in the shopping cart)");
            Console.WriteLine("[D]elete the product from the inventory or return all of a product from the shopping cart to the inventory");
            Console.WriteLine("[Q]uit");
            List<Spring2025_Samples.Models.Product> list = ProductServiceProxy.Current.Products; // must use public getter to access
            //char choice = Console.ReadLine()[0];
            char choice;
            do
            {
                string? input = Console.ReadLine();
                choice = Char.ToUpper(input[0]);
                //choice = input[0];
                //choice = Char.ToUpper(choice);
                switch (choice)
                {
                    case 'C':
                        //var name = Console.ReadLine();
                        // var prod = new Product { Name = name, Id = -1 };
                        ProductServiceProxy.Current.Add(new Product
                        {
                            Name = Console.ReadLine()
                        });
                        break;
                    case 'R':
                        list.ForEach(Console.WriteLine);
                        break;
                    case 'U':
                        Console.WriteLine("Which product would you like to update?");
                        int selection = int.Parse(Console.ReadLine() ?? "-1");
                        var selectedProd = list.FirstOrDefault(p => p.Id == selection); 
                        if(selectedProd != null)
                        {
                            selectedProd.Name = Console.ReadLine() ?? "ERROR";
                        }
                        break;
                    case 'D':
                    Console.WriteLine("Which product would you like to update?");
                        selection = int.Parse(Console.ReadLine() ?? "-1");
                        selectedProd = list.FirstOrDefault(p => p.Id == selection); 
                        list.Remove(selectedProd);
                        break;
                    
                    case 'Q':
                    break;
                    default:
                        Console.WriteLine("Error: Unknown Command");
                        break;
                }
            } while (choice != 'Q' && choice != 'q');

        }
    }
}
