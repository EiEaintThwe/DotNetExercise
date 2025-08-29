using System;
using System.Collections.Generic;

namespace DotNetExercise.MiniPOSDatabase.App3DbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public bool DeleteFlag { get; set; }
}
