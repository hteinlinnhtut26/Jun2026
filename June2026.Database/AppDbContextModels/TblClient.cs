using System;
using System.Collections.Generic;

namespace June2026.Database.AppDbContextModels;

public partial class TblClient
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string Address { get; set; } = null!;
}
