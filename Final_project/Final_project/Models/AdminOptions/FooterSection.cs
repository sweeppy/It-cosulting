using System;
using System.Collections.Generic;

namespace Final_project.Models.AdminOptions;

public partial class FooterSection
{
    public string LocationPhoto { get; set; } = null!;

    public string TextAbout { get; set; } = null!;

    public int ContactsId { get; set; }

    public string ContactsPath { get; set; } = null!;
}
