using System;
using System.Collections.Generic;

namespace DotNetExercise.MiniPOSDatabase.App3DbContextModels;

public partial class TblSaleDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public string ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    public int SalePrice { get; set; }

    public bool DeleteFlag { get; set; }
}
