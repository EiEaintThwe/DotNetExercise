using DotNetExercise.MiniPOSDatabase.App3DbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExercise.MiniPOSConsoleApp
{
    public class SaleDetailService
    {
        public void Read()
        {
            App3DbContext db = new App3DbContext();
            List<TblSaleDetail> lst = db.TblSaleDetails.Where(x => x.DeleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("SaleDetail Id => " + item.SaleDetailId);
                Console.WriteLine("Sale Id => " + item.SaleId);
                Console.WriteLine("Product Id => " + item.ProductId);
                Console.WriteLine("Quantity => " + item.Quantity);
                Console.WriteLine("Sale Price => " + item.SalePrice);
            }


        }

        public void Edit()
        {
            Console.Write("Enter SaleDetail Id : ");
            string saledetailId = Console.ReadLine()!;
            bool isInt = int.TryParse(saledetailId, out int id); ;
            if (!isInt)
            {
                return;
            }

            App3DbContext db = new App3DbContext();
            var item = db.TblSaleDetails.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.SaleDetailId == id);
            if (item == null) return;

            Console.WriteLine("SaleDetail Id => " + item.SaleDetailId);
            Console.WriteLine("Sale Id => " + item.SaleId);
            Console.WriteLine("Product Id => " + item.ProductId);
            Console.WriteLine("Quantity => " + item.Quantity);
            Console.WriteLine("Sale Price => " + item.SalePrice);

        }

        public void Create()
        {
            Console.Write("Enter Sale ID : ");
            string saleId = Console.ReadLine()!;
            bool isIntSale = int.TryParse(saleId, out int id);
            if (!isIntSale) { return; }

            Console.Write("Enter Product ID : ");
            string productId = Console.ReadLine()!;

            Console.Write("Enter Quantity : ");
            string quantity = Console.ReadLine()!;
            bool isIntQty = int.TryParse(saleId, out int qty);
            if (!isIntQty) { return; }

            Console.Write("Enter Sale Price : ");
            string salePrice = Console.ReadLine()!;
            bool isIntPrice = int.TryParse(salePrice, out int price);
            if (!isIntPrice) return;

            TblSaleDetail SaleDetail = new TblSaleDetail() 
            {
                SaleId = id,
                ProductId = productId,
                Quantity = qty,
                SalePrice = price
           
            };

            App3DbContext db = new App3DbContext();
            db.TblSaleDetails.Add(SaleDetail);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving Successful!" : "Saving Failed!");


        }
    }
}
