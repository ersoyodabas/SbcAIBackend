using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for pack_category
    /// </summary>
    public class PackCategoryDto : BaseDto
    {
        public int id { get; set; }

        public short sort_no { get; set; }

        public string langs { get; set; } = null!;

        public bool? selected { get; set; }

        public bool? active { get; set; }
    }
}
