using kudvenkat_ADONET_playlist.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudvenkat_ADONET_playlist.DataAccess
{
    public class Products
    {
        private static string _connectionString = "Data Source=DESKTOP-UN0PLOQ\\SQLEXPRESS;Initial Catalog=Example;Integrated Security=True";
        
        public static IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Example.dbo.kudvenkat_ADONET_playlist_tblProduct", connection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while(sqlDataReader.Read())
                    {
                        products.Add(new Product
                        {
                            productID = int.Parse(sqlDataReader["ProductID"].ToString()),
                            name = sqlDataReader["Name"].ToString(),
                            unitPrice = int.Parse(sqlDataReader["UnitPrice"].ToString()),
                            qtyAvailable = int.Parse(sqlDataReader["QtyAvailable"].ToString())
                        });
                    }
                }
            }
            return products;
        }

        public static void PrintProducts()
        {
            foreach (Product product in Products.GetProducts())
            {
                Console.WriteLine(product.productID.ToString() + "\t" + product.name + "\t" + product.unitPrice.ToString() + "\t" + product.qtyAvailable.ToString());
            }
        }
        public static void UpdateProduct(int productID, string column, string newValue, out string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Example.dbo.kudvenkat_ADONET_playlist_tblProduct SET " + column + " = '" + newValue + "' WHERE ProductID = " + productID.ToString(), connection))
                {
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    message = "Success: Total Rows affected = " + rowsAffected.ToString();
                }

            }
        }

        //
        // Summary:
        //     Adds a Product to the database given a Product.
        public static void AddProduct(Product product, out string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Example.dbo.kudvenkat_ADONET_playlist_tblProduct VALUES ( '" + product.name + "', " + product.unitPrice + ", " + product.qtyAvailable + ")", connection))
                {
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    message = "Product entered: " + product.name + "; Rows affected: " + rowsAffected.ToString();
                }
            }
        }

        public static void DeleteProduct(int productID, out string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand sqlDeleteCommand = new SqlCommand("DELETE FROM Example.dbo.kudvenkat_ADONET_playlist_tblProduct WHERE ProductID = '" + productID + "'", connection))
                {
                    SqlCommand sqlGetNameCommand = new SqlCommand("SELECT Name FROM Example.dbo.kudvenkat_ADONET_playlist_tblProduct WHERE ProductID = '" + productID + "'", connection);
                    string productName = sqlGetNameCommand.ExecuteScalar().ToString();
                    int rowsAffected = sqlDeleteCommand.ExecuteNonQuery();
                    message = "Product Removed: " + productName + "; Rows affected: " + rowsAffected.ToString();
                }
            }
        }
    }
}
