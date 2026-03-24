using System;
using System.Collections.Generic;

namespace Sbc.DAL.Models.Entity;

public partial class announcement
{
    public int id { get; set; }

    public string? type { get; set; }

    public string? icon { get; set; }

    public string? logo { get; set; }

    public string? img_url { get; set; }

    public string? link_url { get; set; }

    public string? desc_tr { get; set; }

    public string? desc_en { get; set; }

    public short? duration { get; set; }

    public bool? return_button { get; set; }

    public string? return_url { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public string? header_tr { get; set; }

    public string? header_en { get; set; }

    public DateTime start_date { get; set; }

    public DateTime end_date { get; set; }
}
