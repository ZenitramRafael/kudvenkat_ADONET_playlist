using System;
using kudvenkat_ADONET_playlist.DataAccess;
using kudvenkat_ADONET_playlist.Model;

namespace kudvenkat_ADONET_playlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! \nHere are all the products:");
            PrintProducts();

            string response = GetUserInput("Would you like to Add, Modify, or Delete a record? If yes, type Add or Modify to contiue. Else, type ReturnAll: ");

            string message;
            while (response != "end")
            {
                Console.Clear();
                PrintProducts();
                switch (response)
                {
                    case "add":
                        Products.AddProduct(GetNewProductFromUser(), out message);
                        Console.WriteLine(message);
                        PrintProducts();
                        break;
                    case "modify":
                        int productID;
                        string column;
                        string newValue;
                        GetModifiedProductFromUser(out productID, out column, out newValue);
                        Products.UpdateProduct(productID, column, newValue, out message);
                        Console.WriteLine(message);
                        PrintProducts();
                        break;
                    case "delete":
                        DeleteProduct(out message);
                        Console.WriteLine(message);
                        break;
                    case "returnall":
                        Console.Clear();
                        PrintProducts();
                        break;
                }

                response = GetUserInput("Would you like to Add or Modify a record? If yes, type Add or Modify to contiue. Else, type ReturnAll: ");
            }

        }

        static string GetUserInput(string label)
        {
            Console.Write(label);
            string input = Console.ReadLine();
            return input;
        }

        static void PrintProducts()
        {
            Console.WriteLine("ProductID\tName\tUnitPrice\tQtyAvailable");
            foreach (Product product in Products.GetProducts())
            {
                Console.WriteLine(product.productID + "\t" + product.name + "\t" + product.unitPrice + "\t" + product.qtyAvailable);
            }
        }

        static Product GetNewProductFromUser()
        {
            Product product = new Product{
                name = GetUserInput("What is the name of the Product you are entering? "),
                unitPrice = int.Parse(GetUserInput("What is the unit price of the product you are entering? ")),
                qtyAvailable = int.Parse(GetUserInput("What is the qty available for the product you are entering?"))
            };
            return product;
        }

        static void GetModifiedProductFromUser(out int productID, out string column, out string newValue)
        {
            productID = int.Parse(GetUserInput("What is the ProductID of the product you are trying to modify?"));
            column = GetUserInput("Type the name of the column you want to modify: ");
            newValue = GetUserInput("Type the value you want instead of what is already there: ");

        }

        static void DeleteProduct(out string message)
        {
            int productID = int.Parse(GetUserInput("What is the ProductID of the record you are trying to delete? "));
            string response = GetUserInput("Are you sure you want to delete this record: ProductID = " + productID.ToString() + "\nType Yes.");
            if (response == "yes")
            {
                Products.DeleteProduct(productID, out message);
            }
            else
            {
                message = "No records deleted.";
            }
        }
    }
}
