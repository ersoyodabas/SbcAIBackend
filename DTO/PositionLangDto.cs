using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for position_lang
    /// </summary>
    public class PositionLangDto : BaseDto
    {
        public int id { get; set; }

        public int position_id { get; set; }

        public string? lang { get; set; }

        public string? name { get; set; }
    }
}
