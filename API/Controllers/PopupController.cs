using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;
using System.IO;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/popup")]
    public class PopupController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUserService _userService;
        private readonly IUserLoginService _userLoginService;

        public PopupController(IWebHostEnvironment hostEnvironment, IUserService userService, IUserLoginService userLoginService)
        {
            _hostEnvironment = hostEnvironment;
            _userService = userService;
            _userLoginService = userLoginService;
        }

        [HttpPost("login-screen")]
        public async Task<IActionResult> LoginScreen([FromBody] LoginRequest request)
        {
            try
            {
                var basePath = Path.Combine(_hostEnvironment.ContentRootPath, "..", "ExtensionJS", "server_scripts", "views", "login");
                var locPath = Path.Combine(_hostEnvironment.ContentRootPath, "..", "ExtensionJS", "server_scripts", "loc", "popup");

                var htmlPath = Path.Combine(basePath, "login.html");
                var cssPath = Path.Combine(basePath, "login.css");

                if (!System.IO.File.Exists(htmlPath) || !System.IO.File.Exists(cssPath))
                {
                    return NotFound("Login files not found");
                }

                var htmlContent = System.IO.File.ReadAllText(htmlPath);
                var cssContent = System.IO.File.ReadAllText(cssPath);

                // Read all JSON files from loc directory
                var responseDict = new Dictionary<string, object>
                {
                    { "html", htmlContent },
                    { "css", cssContent }
                };

                if (System.IO.Directory.Exists(locPath))
                {
                    var jsonFiles = System.IO.Directory.GetFiles(locPath, "*.json");
                    foreach (var jsonFile in jsonFiles)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(jsonFile);
                        var fileContent = System.IO.File.ReadAllText(jsonFile);
                        var jsonData = System.Text.Json.JsonSerializer.Deserialize<object>(fileContent);
                        responseDict.Add($"loc_{fileName}", jsonData);
                    }
                }

                // If user data provided (Google login session exists), get user subscription info
                if (request != null && !string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.GoogleId))
                {
                    Console.WriteLine($"📱 Login screen POST - User info received: {request.Email}");
                    
                    var userResult = await _userService.GetUserByEmailAsync(request.Email);

                    if (userResult.result && userResult.data != null)
                    {
                        var user = (UserDto)userResult.data;
                        Console.WriteLine($"✅ User found: ID={user.id}, Email={user.email}");

                        // Calculate subscription days left
                        var subscriptionLeftDays = user.membership_end_date.HasValue 
                            ? (user.membership_end_date.Value - DateTime.UtcNow).Days 
                            : 0;

                        // Add user subscription data to response
                        responseDict["subscription_left_day"] = subscriptionLeftDays;
                        responseDict["lang_app"] = user.lang_app ?? "en";

                        Console.WriteLine($"💾 Subscription data added - Days: {subscriptionLeftDays}, Lang: {user.lang_app}");
                    }
                    else
                    {
                        Console.WriteLine($"⚠️ User not found for email: {request.Email}");
                        // Return default values
                        responseDict["subscription_left_day"] = 0;
                        responseDict["lang_app"] = request.Lang ?? "en";
                    }
                }
                else
                {
                    Console.WriteLine("📱 Login screen POST - No user data provided (new/guest user)");
                }

                return Ok(responseDict);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error reading login files", error = ex.Message });
            }
        }

        [HttpGet("popup-screen")]
        public IActionResult PopupScreen()
        {
            try
            {
                var basePath = Path.Combine(_hostEnvironment.ContentRootPath, "..", "ExtensionJS", "server_scripts", "popup");
                var locPath = Path.Combine(_hostEnvironment.ContentRootPath, "..", "ExtensionJS", "server_scripts", "loc", "popup");
                
                var htmlPath = Path.Combine(basePath, "popup.html");
                var cssPath = Path.Combine(basePath, "styles.css");

                if (!System.IO.File.Exists(htmlPath) || !System.IO.File.Exists(cssPath))
                {
                    return NotFound(new { message = "Popup files not found", htmlExists = System.IO.File.Exists(htmlPath), cssExists = System.IO.File.Exists(cssPath) });
                }

                var htmlContent = System.IO.File.ReadAllText(htmlPath);
                var cssContent = System.IO.File.ReadAllText(cssPath);

                // Read all JSON files from loc directory
                var responseDict = new Dictionary<string, object>
                {
                    { "html", htmlContent },
                    { "css", cssContent }
                };

                if (System.IO.Directory.Exists(locPath))
                {
                    var jsonFiles = System.IO.Directory.GetFiles(locPath, "*.json");
                    foreach (var jsonFile in jsonFiles)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(jsonFile);
                        var fileContent = System.IO.File.ReadAllText(jsonFile);
                        var jsonData = System.Text.Json.JsonSerializer.Deserialize<object>(fileContent);
                        responseDict.Add($"loc_{fileName}", jsonData);
                    }
                }

                return Ok(responseDict);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error reading popup files", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                // Validation
                if (request == null || string.IsNullOrEmpty(request.Email))
                {
                    return BadRequest(new { message = "Email is required" });
                }

                if (string.IsNullOrEmpty(request.Name))
                {
                    return BadRequest(new { message = "Name is required" });
                }

                if (string.IsNullOrEmpty(request.GoogleId))
                {
                    return BadRequest(new { message = "GoogleId is required" });
                }

                // Get user by email
                var userResult = await _userService.GetUserByEmailAsync(request.Email);
                UserDto user = null;

                if (userResult.result && userResult.data != null)
                {
                    // User exists - kullanıcı mevcut, direkt kullan
                    user = (UserDto)userResult.data;
                    Console.WriteLine($"✅ User bulundu: ID={user.id}, Email={user.email}");
                }
                else
                {
                    // User doesn't exist - create new user (Google login)
                    Console.WriteLine($"🆕 Yeni kullanıcı oluşturuluyor: {request.Email}");
                    
                    var newUser = new UserDto
                    {
                        name = request.Name,
                        email = request.Email,
                        password = GenerateRandomPassword(),
                        active = true,
                        create_date = DateTime.UtcNow,
                        update_date = DateTime.UtcNow,
                        last_login_date_app = DateTime.UtcNow,
                        email_code_sent_date = DateTime.UtcNow,
                        role = "user",
                        lang_app = request.Lang ?? "en",
                        trial_status = "pending",
                        login_limit = 0,
                        max_login_limit = 0,
                        membership_type = request.MembershipType ?? "free",
                        social_logo = request.Picture,
                        username = request.Email // username = email
                    };

                    var saveResult = await _userService.SaveUserAsync(newUser);
                    if (!saveResult.result || saveResult.data == null)
                    {
                        Console.WriteLine($"❌ User oluşturulamadı: {saveResult.message}");
                        return BadRequest(new { message = "User could not be created" });
                    }

                    user = (UserDto)saveResult.data;
                    Console.WriteLine($"✅ Yeni user oluşturuldu: ID={user.id}");
                }

                // Create login record
                var userLoginDto = new UserLoginDto
                {
                    user_id = user.id,
                    type = "web",
                    update_time = DateTime.UtcNow
                };

                var loginResult = await _userLoginService.SaveUserLoginAsync(userLoginDto);

                // Eğer login record oluşturma başarısız olsa da (duplicate/exists ise), 
                // kullanıcı girişi başarılı sayılsın
                if (!loginResult.result)
                {
                    Console.WriteLine($"⚠️ Login record kaydedilemedi (zaten var mı?): {loginResult.message}");
                }
                else
                {
                    Console.WriteLine($"✅ Login record oluşturuldu: User ID={user.id}");
                }

                var response = new
                {
                    success = true,
                    message = "Login successful",
                    userId = user.id,
                    email = user.email,
                    name = user.name,
                    token = GenerateToken(user.email, user.id),
                    subscription_type = user.membership_type,
                    subscription_end_date = user.membership_end_date,
										subscription_left_days = (user.membership_end_date.HasValue ? (user.membership_end_date.Value - DateTime.UtcNow).Days : 0),
                    phone_area = user.phone_area,
                    phone = user.phone,
                    lang_app = user.lang_app,
                    trial_status = user.trial_status,
                    login_limit = user.login_limit,
                    version = user.version
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Login error", error = ex.Message });
            }
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // TODO: Implement proper password hashing verification (e.g., BCrypt)
            // For now, this is a basic comparison (not secure for production)
            return inputPassword == storedPassword;
        }

        private string GenerateRandomPassword()
        {
            // Generate a random password for Google login users
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            return new string(Enumerable.Range(0, 16).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }

        private string GenerateToken(string email, int userId)
        {
            // TODO: Implement proper JWT token generation
            var tokenData = $"{userId}:{email}:{DateTime.UtcNow.Ticks}";
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(tokenData));
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? GoogleId { get; set; }
        public string? Picture { get; set; }
        public string? Lang { get; set; } = "en";
        public string? MembershipType { get; set; } = "free";
    }
}
