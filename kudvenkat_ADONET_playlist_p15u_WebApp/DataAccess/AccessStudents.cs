using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using kudvenkat_ADONET_playlist_p15u_WebApp.Models;
using Microsoft.Extensions.Configuration;

namespace kudvenkat_ADONET_playlist_p15u_WebApp.DataAccess
{
    public class AccessStudents
    {
        //private static IConfiguration configuration;
        //private static string _connection = configuration.GetConnectionString("DefultConnection");
        private static string _connection = "Data Source=DESKTOP-UN0PLOQ\\SQLEXPRESS;Initial Catalog=Example;Integrated Security=True";

        public static IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                string command = "select * from kudvenkat_ADONET_playlist_tblStudents;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, connection);
                sqlDataAdapter.Fill(dataSet, "Students");
            }

            foreach(DataRow dataRow in dataSet.Tables["Students"].Rows)
            {
                students.Add(new Student
                {
                    studentID = int.Parse(dataRow["ID"].ToString())
                    ,
                    name = dataRow["name"].ToString()
                    ,
                    gender = dataRow["gender"].ToString()
                    ,
                    totalMarks = int.Parse(dataRow["TotalMarks"].ToString())
                });
            }
            return students;
        }
    }
}