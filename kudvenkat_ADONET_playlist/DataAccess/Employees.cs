using kudvenkat_ADONET_playlist.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudvenkat_ADONET_playlist.DataAccess
{
    public class Employees
    {
        private static string _connectionString = "Data Source=DESKTOP-UN0PLOQ\\SQLEXPRESS;Initial Catalog=Example;Integrated Security=True";


        public static IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand("prockudvenkat_ADONET_playlist_GetEmployees", connection);
                sqlDataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlDataAdapter.SelectCommand.Parameters.Add[WithValue]("","");
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                foreach(DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    employees.Add(new Employee
                    {
                        employeeId = int.Parse(dataRow["EmployeeID"].ToString())
                        ,
                        name = dataRow["Name"].ToString()
                        ,
                        gender = dataRow["Gender"].ToString()
                        ,
                        salary = int.Parse(dataRow["Salary"].ToString())
                    });
                }
                return employees;
            }
        }
        public static void InsertEmployee(Employee employee, out string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("prockudvenkat_ADONET_playlist_insertEmployees", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", employee.name);
                sqlCommand.Parameters.AddWithValue("@gender", employee.gender);
                sqlCommand.Parameters.AddWithValue("@salary", employee.salary);

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@employeeId";
                sqlParameter.SqlDbType = System.Data.SqlDbType.Int;
                sqlParameter.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameter);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                message = "Record inserted: EmployeeID = " + sqlParameter.Value.ToString();
            }
        }
    }
}
