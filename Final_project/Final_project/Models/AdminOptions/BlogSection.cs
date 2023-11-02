using System;
using System.Collections.Generic;

namespace Final_project.Models.AdminOptions;

public partial class BlogSection
{
    public int Id { get; set; }

    public string Photo { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string Date { get; set; } = null!;
}
