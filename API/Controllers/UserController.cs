using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.DTO.LoginPanel;
using Sbc.SERVICE;
using System.Collections;

namespace Sbc.API.Controllers
{
    /// <summary>
    /// Login panel request model - contains frontend information
    /// </summary>
    public class LoginPanelRequest
    {
        public string email { get; set; }
        public string googleId { get; set; }
        public string lang { get; set; }
    }

    [ApiController]	
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMenuService _menuService;

        public UserController(IUserService service, IMenuService menuService)
        {
            _service = service;
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUsersAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 25,
            [FromQuery] string? search = null,
            [FromQuery] string? role = null,
            [FromQuery] bool? active = null,
            [FromQuery] bool? banned = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] bool sortDesc = true)
        {
            if (page < 1) page = 1;
            if (pageSize < 1 || pageSize > 200) pageSize = 25;

            var result = await _service.GetUsersPagedAsync(page, pageSize, search, role, active, banned, sortBy, sortDesc);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserDto dto)
        {
            var result = await _service.SaveUserAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost("login-panel")]
        public async Task<IActionResult> LoginPanel([FromBody] LoginPanelRequest request)
        {
            try
            {
                // Extract JWT token from Authorization header
                var authHeader = Request.Headers["Authorization"].ToString();
                Console.WriteLine($"[LoginPanel] Authorization header: {(authHeader != "" ? "✅ Present" : "❌ Missing")}");
                
                if (string.IsNullOrEmpty(authHeader))
                {
                    return Unauthorized(new { result = false, message = "Authorization header bulunamadı" });
                }

                // Extract token (remove "Bearer " prefix)
                string token = authHeader.StartsWith("Bearer ") ? authHeader.Substring(7) : authHeader;
                Console.WriteLine($"[LoginPanel] Token length: {token.Length}");

                // Decode JWT token to extract email
                string email = ExtractEmailFromToken(token);
                Console.WriteLine($"[LoginPanel] Extracted email from token: {email}");

                if (string.IsNullOrEmpty(email))
                {
                    return Unauthorized(new { result = false, message = "Token'dan email bilgisi çıkarılamadı" });
                }

                // Get user details from database with startup data and features
                var userResult = await _service.GetUserForLoginPanelAsync(email);
                Console.WriteLine($"[LoginPanel] User query result: {userResult.result}, User found: {userResult.data != null}");

                if (!userResult.result || userResult.data == null)
                {
                    return NotFound(new { result = false, message = "Kullanıcı bulunamadı" });
                }

                // Cast to properly typed LoginPanelResponseDto (no circular reference issues)
                var panelData = (LoginPanelResponseDto)userResult.data;
                var user = panelData.user;
                var userStartupList = panelData.userStartups;
                Console.WriteLine($"[LoginPanel] ✅ User loaded: ID={user.id}, Email={user.email}, Name={user.name}, Startups: {userStartupList.Count}");

                // Calculate subscription days
                var subscriptionLeftDays = user.membership_end_date.HasValue 
                    ? (user.membership_end_date.Value - DateTime.UtcNow).Days 
                    : 0;

                // Load menus from database (ordered by sort_number)
                var menusResult = await _menuService.GetAllMenusAsync();
                ArrayList menusList = new ArrayList();
                if (menusResult.result && menusResult.data != null)
                {
                    var menus = (List<MenuDto>)menusResult.data;
                    // Sort by sort_number
                    var sortedMenus = menus.OrderBy(m => m.sort_number).Where(m => m.active).ToList();
                    foreach (var menu in sortedMenus)
                    {
                        menusList.Add(new { menu.id, menu.code, menu.name, menu.name_en, menu.name_tr, menu.href, menu.img, menu.active, menu.show, menu.sort_number });
                    }
                    Console.WriteLine($"[LoginPanel] ✅ Loaded {menusList.Count} menus from database (ordered by sort_number)");
                }
                else
                {
                    Console.WriteLine($"[LoginPanel] ⚠️ Could not load menus from database");
                }

                // Return important user info for panel
                var response = new
                {
                    result = true,
                    message = "Başarılı",
                    data = new
                    {
                        user = new
                        {
                            user.id,
                            user.email,
                            user.name,
                            user.phone,
                            user.phone_area,
                            subscription_type = user.membership_type,
                            subscription_left_day = subscriptionLeftDays,
                            subscription_end_date = user.membership_end_date,
                            user.lang_app,
                            user.login_limit,
                            user.trial_status
                        },
                        menus = menusList,
                        userStartups = userStartupList
                    }
                };

                Console.WriteLine($"[LoginPanel] ✅ Response prepared");
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginPanel] ❌ Exception: {ex.Message}");
                return BadRequest(new { result = false, message = $"Hata: {ex.Message}" });
            }
        }

        /// <summary>
        /// Extract email from JWT token (Base64 encoded format: userId:email:timestamp)
        /// </summary>
        private string ExtractEmailFromToken(string token)
        {
            try
            {
                // Decode base64 token
                byte[] data = Convert.FromBase64String(token);
                string decodedToken = System.Text.Encoding.UTF8.GetString(data);
                Console.WriteLine($"[ExtractEmail] Decoded token: {decodedToken}");

                // Parse format: userId:email:timestamp
                var parts = decodedToken.Split(':');
                if (parts.Length >= 2)
                {
                    var email = parts[1];
                    Console.WriteLine($"[ExtractEmail] ✅ Email extracted: {email}");
                    return email;
                }
                else
                {
                    Console.WriteLine($"[ExtractEmail] ❌ Invalid token format: {decodedToken}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ExtractEmail] ❌ Decoding error: {ex.Message}");
                return null;
            }
        }
    }
}
