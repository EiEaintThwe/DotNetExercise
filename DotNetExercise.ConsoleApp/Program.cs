
using DotNetExercise.ConsoleApp;
using DotNetExercise.Database.App2DbContextModels;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.InitialCatalog = "DotNetExercise";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sasa@123";
//sqlConnectionStringBuilder.TrustServerCertificate = true;

//SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

//connection.Open();
//connection.Close();

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
////adoDotNetExample.Edit();
////adoDotNetExample.Create();
////adoDotNetExample.Update();
//adoDotNetExample.Delete();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
//dapperExample.Delete();

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit();
//eFCoreExample.Create();
//eFCoreExample.Update();
//eFCoreExample.Delete();

App2DbContext db = new App2DbContext();
db.TblBlogs.ToList();

Console.ReadKey();