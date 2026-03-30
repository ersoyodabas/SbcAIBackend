using System;

namespace Sbc.DTO.LoginPanel
{
    /// <summary>
    /// DTO for login panel - contains only essential user data without circular references
    /// </summary>
    public class LoginPanelUserDto
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string? phone { get; set; }
        public string? phone_area { get; set; }
        public string? membership_type { get; set; }
        public DateTime? membership_end_date { get; set; }
        public string? lang_app { get; set; }
        public short login_limit { get; set; }
        public string? trial_status { get; set; }
    }
}
