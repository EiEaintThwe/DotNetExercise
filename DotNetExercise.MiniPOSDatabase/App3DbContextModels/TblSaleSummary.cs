using System;
using System.Collections.Generic;

namespace DotNetExercise.MiniPOSDatabase.App3DbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public DateTime SaleDate { get; set; }

    public string VoucherNo { get; set; } = null!;

    public int TotalAmt { get; set; }

    public bool DeleteFlag { get; set; }
}
