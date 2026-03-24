using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for sbc_category
    /// </summary>
    public class SbcCategoryDto : BaseDto
    {
        public int id { get; set; }

        public string? code { get; set; }

        public short sort_number { get; set; }

        public bool active { get; set; }

        public bool sync { get; set; }

        public bool selected { get; set; }

        public string? name_en { get; set; }

        public string? name_tr { get; set; }
    }
}
