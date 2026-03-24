using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for country
    /// </summary>
    public class CountryDto : BaseDto
    {
        public int id { get; set; }

        public string title { get; set; } = null!;

        public string code { get; set; } = null!;

        public string phone { get; set; } = null!;

        public bool active { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }
    }
}
