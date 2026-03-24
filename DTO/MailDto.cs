using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for mail
    /// </summary>
    public class MailDto : BaseDto
    {
        public int id { get; set; }

        public string? description { get; set; }

        public string? subject { get; set; }

        public string? body { get; set; }

        public string? users { get; set; }

        public string? error_message { get; set; }

        public int? sort_no { get; set; }

        public DateTime? update_date { get; set; }

        public bool? screen { get; set; }
    }
}
