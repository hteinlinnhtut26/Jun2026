using System;
using System.Collections.Generic;

namespace June2026.Database.AppDbContextModels;

public partial class TblCourse
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public decimal Fee { get; set; }
}
