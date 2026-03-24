using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user_sbc_submit
    /// </summary>
    public class UserSbcSubmitDto : BaseDto
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public int? sbc_id { get; set; }

        public int? account_id { get; set; }

        public DateTime? create_time { get; set; }
    }
}
