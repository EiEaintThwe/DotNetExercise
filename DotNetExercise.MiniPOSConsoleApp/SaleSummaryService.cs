using DotNetExercise.MiniPOSDatabase.App3DbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExercise.MiniPOSConsoleApp
{
    public class SaleSummaryService
    {
        public void Read()
        {
            App3DbContext db = new App3DbContext();
            List<TblSaleSummary> lst = db.TblSaleSummaries.Where(x => x.DeleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("Sale ID => " + item.SaleId);
                Console.WriteLine("Sale Date => " + item.SaleDate);
                Console.WriteLine("Voucher No => " + item.VoucherNo);
                Console.WriteLine("Total Amount => " + item.TotalAmt);
            }

        }

        public void Edit()
        {
            Console.Write("Enter Sale ID : ");
            string saleID = Console.ReadLine()!;
            bool isIntSaleId = int.TryParse(saleID, out int saleid);
            if(!isIntSaleId) { return; }

            App3DbContext db = new App3DbContext();
            var item = db.TblSaleSummaries.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.SaleId == saleid);
            if(item == null) { return; }

            Console.WriteLine("Sale ID => " + item.SaleId);
            Console.WriteLine("Sale Date => " + item.SaleDate);
            Console.WriteLine("Voucher No => " + item.VoucherNo);
            Console.WriteLine("Total Amount => " + item.TotalAmt);


        }

        public void Create()
        {
            Console.Write("Enter Sale Date : ");
            string saleDate = Console.ReadLine()!;
            bool isDate = DateTime.TryParse(saleDate, out DateTime date);
            if(!isDate) { return; }

            Console.Write("Enter Voucher No : ");
            string voucherNo = Console.ReadLine()!;
            Console.Write("Enter Total Amount : ");
            string totalAmt = Console.ReadLine()!;
            bool isIntAmt = int.TryParse(totalAmt, out int amt);
            if(!isIntAmt) { return; }

            TblSaleSummary saleSummary = new TblSaleSummary()
            {
                SaleDate = date,
                VoucherNo = voucherNo,
                TotalAmt = amt
            };

            App3DbContext db = new App3DbContext();
            db.TblSaleSummaries.Add(saleSummary);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving Successful!" : "Saving Failed!");

        }
    }
}
