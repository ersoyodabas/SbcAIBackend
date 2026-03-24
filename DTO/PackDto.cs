using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for pack
    /// </summary>
    public class PackDto : BaseDto
    {
        public int id { get; set; }

        public int category_id { get; set; }

        public string? code { get; set; }

        public string? coin { get; set; }

        public string? fp { get; set; }

        public short sort_no { get; set; }

        public string? langs { get; set; }
    }
}
