using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for menu
    /// </summary>
    public class MenuDto : BaseDto
    {
        public int id { get; set; }

        public string name { get; set; } = null!;

        public int sort_number { get; set; }

        public bool only_admin { get; set; }

        public bool is_active { get; set; }

        public bool show { get; set; }

        public string? type { get; set; }

        public string? href { get; set; }

        public string? img { get; set; }
    }
}
