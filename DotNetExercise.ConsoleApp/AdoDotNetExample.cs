using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExercise.ConsoleApp
{
    public class AdoDotNetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetExercise",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true

        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.Write("BlogID => " + row["BlogID"]);
                Console.Write("BlogTitle => " + row["BlogTitle"]);
                Console.Write("BlogAuthor => " + row["BlogAuthor"]);
                Console.Write("BlogContent => " + row["BlogContent"]);

             }

           


        }
    }
}
