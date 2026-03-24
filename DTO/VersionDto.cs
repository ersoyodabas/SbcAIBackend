using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for version
    /// </summary>
    public class VersionDto : BaseDto
    {
        public int id { get; set; }

        public bool required { get; set; }

        public short version_number { get; set; }

        public DateTime create_date { get; set; }

        public string? season { get; set; }
    }
}
