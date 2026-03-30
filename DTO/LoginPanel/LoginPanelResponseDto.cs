using System.Collections.Generic;

namespace Sbc.DTO.LoginPanel
{
    /// <summary>
    /// Response DTO for login panel containing user and startup data
    /// </summary>
    public class LoginPanelResponseDto
    {
        public LoginPanelUserDto? user { get; set; }
        public List<LoginPanelUserStartupDto> userStartups { get; set; } = new();
    }
}
