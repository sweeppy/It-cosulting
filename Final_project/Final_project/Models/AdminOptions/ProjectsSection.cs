using System;
using System.Collections.Generic;

namespace Final_project.Models.AdminOptions;

public partial class ProjectsSection
{
    public int Id { get; set; }

    public string Photo { get; set; } = null!;

    public string Header { get; set; } = null!;

    public string Text { get; set; } = null!;
}
