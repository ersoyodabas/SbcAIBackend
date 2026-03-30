using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.DTO.LoginPanel;
using Sbc.SERVICE;
using System.Collections;

namespace Sbc.API.Controllers
{
    /// <summary>
    /// Control Panel Model - holds all static assets for control panel
    /// </summary>
    public class CpanelModel
    {
        public string css { get; set; }
        public string html_app { get; set; }
        public ArrayList html_modals { get; set; }
        public ArrayList html_features { get; set; }
        public string loc { get; set; }
    }

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

                // Determine language: use request language if provided, otherwise use user's language preference
                string targetLang = !string.IsNullOrEmpty(request?.lang) ? request.lang.ToLower() : user.lang_app?.ToLower() ?? "en";
                Console.WriteLine($"[LoginPanel] Target language - Request: {request?.lang}, User pref: {user.lang_app}, Using: {targetLang}");

                // Load all cpanel static assets (HTML, CSS, JS) with language localization
                var cpanelModel = LoadCpanelAssets(targetLang);
                Console.WriteLine($"[LoginPanel] Loaded cpanel assets - CSS: {(cpanelModel.css?.Length ?? 0)} chars, App: {(cpanelModel.html_app != null ? "✅" : "❌")}, Modals: {cpanelModel.html_modals?.Count ?? 0}, Features: {cpanelModel.html_features?.Count ?? 0}, Loc: {(cpanelModel.loc?.Length ?? 0)} chars");

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
                        userStartups = userStartupList,
                        cpanel = cpanelModel
                    }
                };

                Console.WriteLine($"[LoginPanel] ✅ Response prepared with cpanel assets");
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



        /// <summary>
        /// Load all cpanel static assets from server_scripts/cpanel directory
        /// </summary>
        private CpanelModel LoadCpanelAssets(string lang = "en")
        {
            var cpanelModel = new CpanelModel
            {
                css = "",
                html_app = "",
                html_modals = new ArrayList(),
                html_features = new ArrayList(),
                loc = ""
            };

            try
            {
                // Get path to server_scripts/cpanel
                var cpanelPath = Path.GetFullPath(Path.Combine(
                    AppContext.BaseDirectory,
                    "..", "..", "..", "..",
                    "ExtensionJS", "server_scripts", "cpanel"
                ));

                Console.WriteLine($"[LoadCpanelAssets] Looking for cpanel assets in: {cpanelPath}");

                if (!Directory.Exists(cpanelPath))
                {
                    Console.WriteLine($"[LoadCpanelAssets] ⚠️ Directory does not exist: {cpanelPath}");
                    return cpanelModel;
                }

                // Load CSS files from css folder and combine them
                var cssPath = Path.Combine(cpanelPath, "css");
                var combinedCss = "";
                if (Directory.Exists(cssPath))
                {
                    Console.WriteLine($"[LoadCpanelAssets] Loading CSS files from: {cssPath}");
                    var cssFiles = Directory.GetFiles(cssPath, "*.css");
                    foreach (var cssFile in cssFiles)
                    {
                        try
                        {
                            var content = System.IO.File.ReadAllText(cssFile);
                            if (!string.IsNullOrWhiteSpace(content))
                            {
                                combinedCss += content + "\n";
                                Console.WriteLine($"[LoadCpanelAssets] ✅ Loaded CSS: {Path.GetFileName(cssFile)}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[LoadCpanelAssets] ❌ Error reading CSS file: {ex.Message}");
                        }
                    }
                    cpanelModel.css = combinedCss.Trim();
                }

                // Load app.html from views folder first
                var viewsPath = Path.Combine(cpanelPath, "views");
                var appHtmlPath = Path.Combine(viewsPath, "app.html");
                if (System.IO.File.Exists(appHtmlPath))
                {
                    try
                    {
                        var content = System.IO.File.ReadAllText(appHtmlPath);
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            cpanelModel.html_app = content;
                            Console.WriteLine($"[LoadCpanelAssets] ✅ Loaded app.html from views");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[LoadCpanelAssets] ❌ Error reading app.html: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"[LoadCpanelAssets] ⚠️ app.html not found at: {appHtmlPath}");
                }

                // Load other HTML files from views folder
                if (Directory.Exists(viewsPath))
                {
                    Console.WriteLine($"[LoadCpanelAssets] Loading HTML files from: {viewsPath}");
                    var htmlFiles = Directory.GetFiles(viewsPath, "*.html", SearchOption.AllDirectories);
                    foreach (var htmlFile in htmlFiles)
                    {
                        try
                        {
                            var fileName = Path.GetFileName(htmlFile);
                            
                            // Skip app.html - already loaded above
                            if (fileName == "app.html")
                                continue;

                            var content = System.IO.File.ReadAllText(htmlFile);
                            if (!string.IsNullOrWhiteSpace(content))
                            {
                                // Modal files (_modals subfolder or files starting with _)
                                if (htmlFile.Contains("_modals") || fileName.StartsWith("_"))
                                {
                                    cpanelModel.html_modals.Add(new { name = fileName, content = content });
                                    Console.WriteLine($"[LoadCpanelAssets] ✅ Loaded modal HTML: {fileName}");
                                }
                                else
                                {
                                    cpanelModel.html_features.Add(new { name = fileName, content = content });
                                    Console.WriteLine($"[LoadCpanelAssets] ✅ Loaded feature HTML: {fileName}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[LoadCpanelAssets] ❌ Error reading HTML file: {ex.Message}");
                        }
                    }
                }

                // Load localization file based on language
                var locPath = Path.Combine(cpanelPath, "loc");
                var langFile = lang?.ToLower() == "tr" ? "tr.json" : "en.json";
                var locFilePath = Path.Combine(locPath, langFile);
                if (System.IO.File.Exists(locFilePath))
                {
                    try
                    {
                        var locContent = System.IO.File.ReadAllText(locFilePath);
                        if (!string.IsNullOrWhiteSpace(locContent))
                        {
                            cpanelModel.loc = locContent;
                            Console.WriteLine($"[LoadCpanelAssets] ✅ Loaded localization: {langFile} ({locContent.Length} chars)");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[LoadCpanelAssets] ❌ Error reading localization file: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"[LoadCpanelAssets] ⚠️ Localization file not found at: {locFilePath}");
                }

                Console.WriteLine($"[LoadCpanelAssets] ✅ Completed - CSS: {(cpanelModel.css?.Length ?? 0)} chars, App: {(cpanelModel.html_app != null ? "✅" : "❌")}, Modals: {cpanelModel.html_modals.Count}, Features: {cpanelModel.html_features.Count}, Loc: {(cpanelModel.loc?.Length ?? 0)} chars");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoadCpanelAssets] ❌ Error: {ex.Message}");
            }

            return cpanelModel;
        }
    }
}
