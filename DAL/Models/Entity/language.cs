using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class language
{
    public string code { get; set; } = null!;

    public string? name { get; set; }

    public string? flag { get; set; }

    public int? sort_number { get; set; }

    public bool? active { get; set; }
}
