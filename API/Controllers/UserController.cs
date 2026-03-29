using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
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
        public async Task<IActionResult> LoginPanel()
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

                // Get user details from database
                var userResult = await _service.GetUserByEmailAsync(email);
                Console.WriteLine($"[LoginPanel] User query result: {userResult.result}, User found: {userResult.data != null}");

                if (!userResult.result || userResult.data == null)
                {
                    return NotFound(new { result = false, message = "Kullanıcı bulunamadı" });
                }

                var user = (UserDto)userResult.data;
                Console.WriteLine($"[LoginPanel] ✅ User loaded: ID={user.id}, Email={user.email}, Name={user.name}");

                // Calculate subscription days
                var subscriptionLeftDays = user.membership_end_date.HasValue 
                    ? (user.membership_end_date.Value - DateTime.UtcNow).Days 
                    : 0;

                // Load HTML files from server_scripts/cpanel/html
                var htmlFiles = LoadHtmlFiles();
                Console.WriteLine($"[LoginPanel] Loaded {htmlFiles.Count} HTML files");

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
                        htmlFiles = htmlFiles
                    }
                };

                Console.WriteLine($"[LoginPanel] ✅ Response prepared with {htmlFiles.Count} HTML files");
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
        /// Load HTML files from server_scripts/cpanel/html directory
        /// </summary>
        private List<dynamic> LoadHtmlFiles()
        {
            var htmlFiles = new List<dynamic>();

            try
            {
                // Get path to server_scripts/cpanel/html
                // AppContext.BaseDirectory: /Backend/API/bin/Debug/net9.0/
                // Go up 4 levels to reach Backend root, then navigate to ExtensionJS
                var htmlPath = Path.GetFullPath(Path.Combine(
                    AppContext.BaseDirectory,
                    "..", "..", "..", "..",
                    "ExtensionJS", "server_scripts", "cpanel", "html"
                ));
                
                Console.WriteLine($"[LoadHtmlFiles] Looking for HTML files in: {htmlPath}");

                if (!Directory.Exists(htmlPath))
                {
                    Console.WriteLine($"[LoadHtmlFiles] ⚠️ Directory does not exist: {htmlPath}");
                    return htmlFiles;
                }

                // Get all .html files
                var files = Directory.GetFiles(htmlPath, "*.html");
                Console.WriteLine($"[LoadHtmlFiles] Found {files.Length} HTML files");

                foreach (var filePath in files)
                {
                    try
                    {
                        var fileName = Path.GetFileName(filePath);
                        var content = System.IO.File.ReadAllText(filePath);
                        
                        // Skip empty files
                        if (string.IsNullOrWhiteSpace(content))
                        {
                            Console.WriteLine($"[LoadHtmlFiles] ⊘ Skipping empty file: {fileName}");
                            continue;
                        }
                        
                        htmlFiles.Add(new
                        {
                            name = fileName,
                            content = content
                        });
                        
                        Console.WriteLine($"[LoadHtmlFiles] ✅ Loaded: {fileName} ({content.Length} bytes)");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[LoadHtmlFiles] ❌ Error reading file {Path.GetFileName(filePath)}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoadHtmlFiles] ❌ Error: {ex.Message}");
            }

            return htmlFiles;
        }
    }
}
