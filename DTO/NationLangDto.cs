using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for nation_lang
    /// </summary>
    public class NationLangDto : BaseDto
    {
        public int id { get; set; }

        public int nation_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;

        public string? manager_lang_code { get; set; }

        public DateTime? create_date { get; set; }

        public DateTime? update_date { get; set; }
    }
}
