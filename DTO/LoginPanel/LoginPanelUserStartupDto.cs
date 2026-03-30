using System;

namespace Sbc.DTO.LoginPanel
{
    /// <summary>
    /// DTO for user startup in login panel - flattened structure without circular references
    /// </summary>
    public class LoginPanelUserStartupDto
    {
        public int id { get; set; }
        public int? sort_number { get; set; }
        public int? feature_id { get; set; }
        public bool? active { get; set; }
        public DateTime? create_date { get; set; }
        public string? value1 { get; set; }
        public string? value2 { get; set; }
        public DateTime? update_time { get; set; }
        
        // Flattened feature data (no circular reference back to user_startup)
        public LoginPanelFeatureDto? feature { get; set; }
    }
}
