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
    }
}
