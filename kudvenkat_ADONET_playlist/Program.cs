using System;
using System.Collections.Generic;
using System.Data;
using kudvenkat_ADONET_playlist.DataAccess;
using kudvenkat_ADONET_playlist.Model;

namespace kudvenkat_ADONET_playlist
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = GetUserInput("How would you like to preform CRUD operations? Basic or StoredProcedure?").ToLower();

            while (response != "end")
            {
                switch (response)
                {
                    case "basic":
                        BasicCRUD();
                        response = "end";
                        break;
                    case "storedprocedure":
                        SPRead();
                        response = "end";
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Not a valid response. Try again or type End to end the program.");
                        response = GetUserInput("How would you like to preform CRUD operations? Basic or StoredProcedure?").ToLower();
                        break;
                }
            }
        }

        static void SPRead()
        {
            string response = GetUserInput("Would you like to insert an Employee? Type Yes. Type All to see to All Employees. ");
            string message;
            switch (response)
            {
                case "all":
                    response = GetUserInput("Would you like to see how//if cache works? Type Products to see Products").ToLower();
                    switch (response)
                    {
                        case "products":
                            Console.WriteLine("Hello World! \nHere are all the products:");
                            PrintProducts();
                            PrintProducts("stored procedure");
                            PrintProducts("p");
                            PrintProducts("sp");
                            break;
                        case "yes":
                            Console.Clear();
                            //string isCached;
                            PrintEmployees(Employees.GetEmployees(/*out isCached*/));
                            //Console.WriteLine(isCached);
                            Employees.InsertEmployee(InsertEmployee(), out message);
                            Console.WriteLine(message);
                            PrintEmployees(Employees.GetEmployees(/*out isCached*/));
                            //Console.WriteLine(isCached);
                            break;
                    }
                    
                    break;
                case "yes":
                    Employees.InsertEmployee(InsertEmployee(), out message);
                    Console.WriteLine(message);
                    break;
            }
        }



        static void BasicCRUD()
        {
            Console.WriteLine("Hello World! \nHere are all the products:");
            PrintProducts();

            string response = GetUserInput("Would you like to Add, Modify, or Delete a record? If yes, type Add or Modify to contiue. Else, type ReturnAll. \n" +
                "To quit the program, type End\n");

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

        #region Methods for Employees
        private static Employee InsertEmployee()
        {
            Employee employee = new Employee
            {
                name = GetUserInput("What is the name of the Employee being inserted? ")
                ,
                gender = GetUserInput("What is the gender of the Employee being inserted? ")
                ,
                salary = int.Parse(GetUserInput("What is the salary of the Employee being inserted? "))
            };
            return employee;
        }

        private static void PrintEmployees(IEnumerable<Employee> employees)
        {
            Console.WriteLine("EmployeeID\tName\tGender\tSalary");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.employeeId + "\t" + employee.name + "\t" + employee.gender + "\t" + employee.salary);
            }
            Console.WriteLine("Employees printed from dataSet.");
        }

        #endregion

        #region Methods for all runs (Basic and StoredProcedure)
        static string GetUserInput(string label)
        {
            Console.Write(label);
            string input = Console.ReadLine();
            return input;
        }

        static void PrintProducts(string sp = "x")
        {
            if (sp.ToLower() == "p")
            {
                string response = GetUserInput("Get product with parameter for standard query. Type ProductID: ");
                Console.WriteLine("ProductID = " + response);
                Console.WriteLine("ProductID\tName\tUnitPrice\tQtyAvailable");
                foreach (Product product in SPProducts.GetProducts(int.Parse(response)))
                {
                    Console.WriteLine(product.productID + "\t" + product.name + "\t" + product.unitPrice + "\t" + product.qtyAvailable);
                }
            }
            else if (sp.ToLower() == "sp") {
                string response = GetUserInput("Get product with stored procedure and parameter. Type ProductionID: ");
                Console.WriteLine("ProductID = " + response);
                Console.WriteLine("ProductID\tName\tUnitPrice\tQtyAvailable");
                foreach (Product product in SPProducts.GetProductsSP(int.Parse(response)))
                {
                    Console.WriteLine(product.productID + "\t" + product.name + "\t" + product.unitPrice + "\t" + product.qtyAvailable);
                }
            }
            else if (sp.ToLower() == "x")
            {
                Console.WriteLine("Get All products from standard query");
                Console.WriteLine("ProductID\tName\tUnitPrice\tQtyAvailable");
                foreach (Product product in Products.GetProducts())
                {
                    Console.WriteLine(product.productID + "\t" + product.name + "\t" + product.unitPrice + "\t" + product.qtyAvailable);
                }
            }
            else
            {
                Console.WriteLine("Get All products from stored procedure");
                Console.WriteLine("ProductID\tName\tUnitPrice\tQtyAvailable");
                foreach (Product product in SPProducts.GetProductsSP())
                {
                    Console.WriteLine(product.productID + "\t" + product.name + "\t" + product.unitPrice + "\t" + product.qtyAvailable);
                }
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
        #endregion


        #region Methods for Basic run
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
        #endregion


        #region Methods for StoredProcedure run (empty)

        #endregion
    }
}
