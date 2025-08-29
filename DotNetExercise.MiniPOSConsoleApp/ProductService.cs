using DotNetExercise.MiniPOSDatabase.App3DbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExercise.MiniPOSConsoleApp
{
    public class ProductService
    {
        public void Read()
        {
            App3DbContext db = new App3DbContext();
            List<TblProduct> lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();

            foreach(var item in lst)
            {
                Console.WriteLine("Product ID => " + item.ProductId);
                Console.WriteLine("Product Code => " + item.ProductCode);
                Console.WriteLine("Product Name => " + item.ProductName);
                Console.WriteLine("Product Price => " + item.ProductPrice);
            }

        }

        public void Edit()
        {
            Console.Write("Enter Product ID : ");
            string productID = Console.ReadLine()!;
            bool isInt = int.TryParse(productID, out int id);
            if (!isInt)
            {
                return;
            }

            App3DbContext db = new App3DbContext();
           var item = db.TblProducts.Where (x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            if(item == null)
            {
                return;
            }

            Console.WriteLine("Product ID => " + item.ProductId);
            Console.WriteLine("Product Code => " + item.ProductCode);
            Console.WriteLine("Product Name => " + item.ProductName);
            Console.WriteLine("Product Price => " + item.ProductPrice);

        }

        public void Create()
        {
            Console.Write("Enter Product Code : ");
            string productCode = Console.ReadLine()!;
            Console.Write("Enter Product Name : ");
            string productName = Console.ReadLine()!;
            Console.Write("Enter Product Price : ");
            string productPrice = Console.ReadLine()!;
            bool isInt = int.TryParse(productPrice, out int price);
            if (!isInt) {
                return;
            }

            TblProduct product = new TblProduct()
            {
                ProductCode = productCode,
                ProductName = productName,
                ProductPrice = price
            };

            App3DbContext db = new App3DbContext();
            db.TblProducts.Add(product);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving Successful!" : "Saving Failed!");


        }

        public void Update()
        {
            Console.Write("Enter Product ID : ");
            string productID = Console.ReadLine()!;
            bool isInt = int.TryParse(productID, out int id);
            if (!isInt)
            {
                return;
            }

            Console.Write("Modify Product Code : ");
            string productCode = Console.ReadLine()!;
            Console.Write("Modify Product Name : ");
            string productName = Console.ReadLine()!;
            Console.Write("Modify Product Price : ");
            string productPrice = Console.ReadLine()!;
            bool isIntPrice = int.TryParse(productPrice, out int price);
            if (!isIntPrice)
            {
                return;
            }

            bool isExist = IsExistProduct(id);
            if (!isExist) return;

            App3DbContext db = new App3DbContext();
            var item = db.TblProducts.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            item.ProductCode = productCode;
            item.ProductName = productName;
            item.ProductPrice = price;

            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating Successful!" : "Updating Failed!");

        }

        public void Delete()
        {
            Console.Write("Enter Product ID : ");
            string productID = Console.ReadLine()!;
            bool isInt = int.TryParse(productID, out int id);
            if (!isInt) { return; }

            bool isExist = IsExistProduct(id);
            if (!isExist) { return; }

            App3DbContext db = new App3DbContext();
            var item = db.TblProducts.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            item.DeleteFlag = true;

            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting Successful!" : "Deleting Failed!");
        }

        private bool IsExistProduct(int id)
        {
            App3DbContext db = new App3DbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
           return item != null;
        }

    }
}
