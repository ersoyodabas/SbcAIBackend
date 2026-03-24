using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for club_lang
    /// </summary>
    public class ClubLangDto : BaseDto
    {
        public int id { get; set; }

        public int club_id { get; set; }

        public string lang { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
