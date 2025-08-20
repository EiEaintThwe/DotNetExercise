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
            string query = "select * from Tbl_Blog";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
             
                Console.WriteLine("BlogID => " + row["BlogID"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
             

            }



        }

        public void Edit()
        {
            Console.Write("Enter ID : ");
            string blogId = Console.ReadLine()!;

            //string query = $"select * from Tbl_Blog where BlogID = {blogId}";
            string query = $"select * from Tbl_Blog where BlogID = @BlogID";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", blogId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);

                Console.WriteLine("BlogID => " + row["BlogID"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);


            }
        }

        public void Create()
        {
            //       string query = @"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent]
            //      ,[DeleteFlag])
            //VALUES
            //      ('Test'
            //      ,'TestAuthor'
            //      ,'TestContent'
            //      ,0)";
            Console.Write("Enter title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter content : ");
            string content = Console.ReadLine()!;

            //       string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent]
            //      ,[DeleteFlag])
            //VALUES
            //      ('{title}'
            //      ,'{author}'
            //      ,'{content}'
            //      ,0)";

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@Title,
           ,@Author,
           ,@Content
           ,0)";


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title",title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0 ? "Insert Successful!" : "Insert Failed!");
        }

        public void Update()
        {
            Console.Write("Enter ID : ");
            string id = Console.ReadLine()!;

            Console.Write("Enter title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter content : ");
            string content = Console.ReadLine()!;

           

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogID = @BlogID";


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0 ? "Update Successful!" : "Update Failed!");
        }

        public void Delete()
        {

            Console.Write("Enter ID : ");
            string id = Console.ReadLine()!;


            string query = $@"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogID = @BlogID";


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0 ? "Delete Successful!" : "Delete Failed!");
        }

    }
}
