using kudvenkat_ADONET_playlist.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudvenkat_ADONET_playlist.DataAccess
{
    public class SPProducts
    {
        private static string _connectionString = "Data Source=DESKTOP-UN0PLOQ\\SQLEXPRESS;Initial Catalog=Example;Integrated Security=True";

        public static IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM kudvenkat_ADONET_playlist_tblProduct", connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    products.Add(new Product
                    {
                        productID = int.Parse(sqlDataReader["ProductID"].ToString()),
                        name = sqlDataReader["Name"].ToString(),
                        unitPrice = int.Parse(sqlDataReader["UnitPrice"].ToString()),
                        qtyAvailable = int.Parse(sqlDataReader["QtyAvailable"].ToString())
                    });
                }
                return products;
            }
        }
        public static IEnumerable<Product> GetProducts(int productID)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM kudvenkat_ADONET_playlist_tblProduct" +
                    " WHERE ProductID = @productID", connection);
                sqlCommand.Parameters.AddWithValue("@productID", productID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    products.Add(new Product
                    {
                        productID = productID,
                        name = sqlDataReader["Name"].ToString(),
                        unitPrice = int.Parse(sqlDataReader["UnitPrice"].ToString()),
                        qtyAvailable = int.Parse(sqlDataReader["QtyAvailable"].ToString())
                    });
                }
            }
            return products;
        }

        public static IEnumerable<Product> GetProductsSP(int productID = 0)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("prockudvenkat_ADONET_playlist_getProducts", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@productID", productID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    products.Add(new Product
                    {
                        productID = int.Parse(sqlDataReader["ProductID"].ToString()),
                        name = sqlDataReader["Name"].ToString(),
                        unitPrice = int.Parse(sqlDataReader["UnitPrice"].ToString()),
                        qtyAvailable = int.Parse(sqlDataReader["QtyAvailable"].ToString())
                    });
                }
                return products;
            }
        }
    }
}
