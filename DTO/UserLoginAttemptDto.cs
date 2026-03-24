using System;

namespace Sbc.DTO
{
    /// <summary>
    /// DTO for user_login_attempt
    /// </summary>
    public class UserLoginAttemptDto : BaseDto
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public string? ip { get; set; }

        public DateTime create_date { get; set; }
    }
}
