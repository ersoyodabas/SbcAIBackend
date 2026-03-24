using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for league_lang
    /// </summary>
    public class LeagueLangDto : BaseDto
    {
        public int id { get; set; }

        public int league_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
