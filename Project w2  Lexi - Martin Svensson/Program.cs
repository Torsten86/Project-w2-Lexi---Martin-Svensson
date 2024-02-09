
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Product> productList = new List<Product>();

        char userChoice;

        do
        {
            // Ask the user for the action
            Console.WriteLine("------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press 'A' to add a new item, 'P' to display the table, or 'Q' to quit: ");
            userChoice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Move to the next line after the user's input
            Console.ResetColor();

            switch (char.ToUpper(userChoice))
            {
                case 'A':
                    // Collect input from the user
                    Console.Write("Enter the category: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter the product name: ");
                    string productName = Console.ReadLine();

                    Console.Write("Enter the price: ");
                    decimal price;
                    if (decimal.TryParse(Console.ReadLine(), out price))
                    {
                        // Create a new product instance
                        Product newProduct = new Product
                        {
                            Category = category,
                            ProductName = productName,
                            Price = price
                        };

                        // Add the product to the list
                        productList.Add(newProduct);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nProduct added successfully.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid price input. Please try again.");
                    }

                    Console.ResetColor();

                    break;

                case 'P':
                    // Sort the products by price (from lowest to highest)
                    productList = productList.OrderBy(product => product.Price).ToList();

                    // Display the final sorted list of products as a table with total sum
                    Console.WriteLine("\nList of Products (Sorted by Price):");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0,-15} {1,-15} {2,-10}", "Category", "Product", "Price");
                    Console.ResetColor();

                    foreach (var product in productList)
                    {
                        Console.Write("{0,-15} {1,-15} ", product.Category, product.ProductName);
                        Console.WriteLine("{0,-10:C}", product.Price);
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nTotal Sum of Prices: {0:C}", productList.Sum(product => product.Price));
                    Console.ResetColor();
                    break;

                case 'Q':
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ResetColor();

                    break;
            }

        } while (char.ToUpper(userChoice) != 'Q');
    }
}
