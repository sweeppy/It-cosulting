using System;
using System.Collections.Generic;

namespace Final_project.Models;

public partial class Application
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;
}
