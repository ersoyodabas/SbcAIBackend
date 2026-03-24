using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for league
    /// </summary>
    public class LeagueDto : BaseDto
    {
        public int id { get; set; }

        public string? code { get; set; }

        public string? icon_url { get; set; }

        public bool active { get; set; }

        public DateTime? create_date { get; set; }

        public int? sort_number { get; set; }

        public string? name_en { get; set; }

        public string? name_tr { get; set; }
    }
}
