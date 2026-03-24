using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class version
{
    public int id { get; set; }

    public bool required { get; set; }

    public short version_number { get; set; }

    public DateTime create_date { get; set; }

    public string? season { get; set; }
}
