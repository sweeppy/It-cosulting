using System;
using System.Collections.Generic;

namespace Final_project.Models.AdminOptions;

public partial class ServicesSection
{
    public int Id { get; set; }

    public string HeaderOfService { get; set; } = null!;

    public string Text { get; set; } = null!;
}
