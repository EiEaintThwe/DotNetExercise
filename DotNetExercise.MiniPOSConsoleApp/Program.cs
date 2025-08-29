// See https://aka.ms/new-console-template for more information
using DotNetExercise.MiniPOSConsoleApp;

Console.WriteLine("Hello, World!");

ProductService productService = new ProductService();
//productService.Read();
//productService.Edit();
//productService.Create();
//productService.Update();
//productService.Delete();

SaleDetailService saleDetailService = new SaleDetailService();
//saleDetailService.Read();
//saleDetailService.Edit();
//saleDetailService.Create();

Console.ReadKey();
