using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExercise.ConsoleApp
{
    public class DapperExample
    {
         private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
         {
             DataSource = ".",
             InitialCatalog = "DotNetExercise",
             UserID = "sa",
             Password = "sasa@123",
             TrustServerCertificate = true
         };

        public void Read()
        {
            using(IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();
                foreach(var item in lst)
                {
                    Console.WriteLine("BlogID => " + item.BlogID);
                    Console.WriteLine("BlogTitle => " + item.BlogTitle);
                    Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                    Console.WriteLine("BlogContent => " + item.BlogContent);
                }
            }

        }

        public void Edit()
        {
        FirstPage:
            //object a = new { BlogID = 1 , BlogTitle ="Mg Mg"};
            Console.Write("Enter ID : ");
            string input = Console.ReadLine()!;
           bool isInt = int.TryParse(input, out int id);
            // if(isInt == false)
            if (!isInt)
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
            
                goto FirstPage;
            }
      
            using(IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from tbl_blog where BlogID= @BlogID", new BlogDto { BlogID = id });
                if(item == null)
                {
                    Console.WriteLine("Blog not found with id : " + id);
                    return;
                }
                Console.WriteLine("BlogID => " + item.BlogID);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);

            }

        }

        public void Create()
        {

            Console.Write("Title : ");
            string title = Console.ReadLine()!;
            Console.Write("Author : ");
            string author = Console.ReadLine()!;
            Console.Write("Content : ");
            string content = Console.ReadLine()!;

            BlogDto blog =  new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";
            using(IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
               int result = db.Execute(query,blog);
                Console.WriteLine(result > 0 ? "Saving Successful" : "Saving Failed");
            }

        }

        public void Update ()
        {
        FirstPage:
            Console.Write("ID : ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Invaild ID. Please enter a valid integer.");
                goto FirstPage;
            }

            Console.Write("Modify Title : ");
            string title = Console.ReadLine()!;
            Console.Write("Modify Author : ");
            string author = Console.ReadLine()!;
            Console.Write("Modify Content : ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogID = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogID = @BlogID";

            using(IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query,blog);
                Console.WriteLine(result > 0 ? "Updating Successful" : "Updating Failed");
            }

        }

        public void Delete()
        {
        FirstPage:
            Console.Write("ID : ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid id. Please enter a valid integer");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString)) {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from tbl_blog where BlogID=@BlogID", new BlogDto { BlogID = id });
                if (item == null)
                {
                    Console.WriteLine("Blog not found with id : " + id);
                    return;

                }

                string query = "delete from tbl_blog where BlogID=@BlogID";
                var result = db.Execute(query,new BlogDto { BlogID = id });
                Console.WriteLine(result > 0 ? "Deleting Successful" : "Deleting Failed");
            }
        }
    }
}
