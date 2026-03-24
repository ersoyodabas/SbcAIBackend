using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for sbc_lang
    /// </summary>
    public class SbcLangDto : BaseDto
    {
        public int id { get; set; }

        public int sbc_id { get; set; }

        public string lang { get; set; } = null!;

        public string sbc_name { get; set; } = null!;

        public string? reward_name { get; set; }
    }
}
