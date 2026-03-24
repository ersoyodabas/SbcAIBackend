using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for vw_request_log
    /// </summary>
    public class VwRequestLogDto : BaseDto
    {
        public string? user_name { get; set; }

        public int id { get; set; }

        public int? user_id { get; set; }

        public string? used_token { get; set; }

        public string req_url { get; set; } = null!;

        public string ip_address_remote { get; set; } = null!;

        public string user_agent { get; set; } = null!;

        public DateTime create_time { get; set; }
    }
}
