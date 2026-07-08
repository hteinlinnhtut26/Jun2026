using System;
using System.Collections.Generic;

namespace June2026.Database.AppDbContextModels;

public partial class TableAcc
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public int Password { get; set; }
}
