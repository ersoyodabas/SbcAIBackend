using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sbc.API.Models;
using Sbc.DAL.Models.Entity;

namespace Sbc.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("google")]
    public async Task<IActionResult> Google([FromBody] GoogleAuthRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Credential))
        {
            return BadRequest(new { success = false, message = "Google credential zorunludur." });
        }

        GoogleTokenPayload payload;

        try
        {
            payload = ParseGooglePayload(request.Credential);
        }
        catch
        {
            return BadRequest(new { success = false, message = "Google credential gecersiz." });
        }

        if (string.IsNullOrWhiteSpace(payload.Email))
        {
            return BadRequest(new { success = false, message = "Google hesabindan e-posta bilgisi alinamadi." });
        }

        var normalizedEmail = payload.Email.Trim().ToLowerInvariant();

        await using var dbContext = new _DbContext();

        var existingUser = await dbContext.user.FirstOrDefaultAsync(user => user.email.ToLower() == normalizedEmail);
        var isNewUser = false;

        if (existingUser == null)
        {
            existingUser = new user
            {
                name = string.IsNullOrWhiteSpace(payload.Name) ? normalizedEmail.Split('@')[0] : payload.Name.Trim(),
                email = normalizedEmail,
                password = Convert.ToHexString(RandomNumberGenerator.GetBytes(32)),
                max_login_limit = 10,
                banned = false,
                create_date = DateTime.UtcNow,
                has_reseller = false,
                lang_app = "tr",
                reseller = false,
                expire_mail_sent = false,
                login_limit = 1,
                active = true,
                register_source = "google_oauth",
                last_login_date_app = DateTime.UtcNow,
                last_active_date_app = DateTime.UtcNow,
                note = "Auto-registered with Google login"
            };

            dbContext.user.Add(existingUser);
            isNewUser = true;
        }
        else
        {
            if (existingUser.banned || existingUser.active == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new
                {
                    success = false,
                    message = "Bu hesap giris icin uygun durumda degil."
                });
            }

            if (string.IsNullOrWhiteSpace(existingUser.name) && !string.IsNullOrWhiteSpace(payload.Name))
            {
                existingUser.name = payload.Name.Trim();
            }

            existingUser.last_login_date_app = DateTime.UtcNow;
            existingUser.last_active_date_app = DateTime.UtcNow;
            existingUser.update_date = DateTime.UtcNow;
        }

        await dbContext.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            message = isNewUser ? "Kullanici kaydi olusturuldu ve giris yapildi." : "Giris basarili.",
            isNewUser,
            token = BuildSessionToken(existingUser),
            user = new
            {
                id = existingUser.id,
                name = existingUser.name,
                email = existingUser.email,
                role = existingUser.role,
                subscriptionType = existingUser.subscription_type,
                active = existingUser.active,
                registerSource = existingUser.register_source
            }
        });
    }

    private static string BuildSessionToken(user user)
    {
        var tokenPayload = new
        {
            userId = user.id,
            email = user.email,
            issuedAt = DateTime.UtcNow
        };

        return Convert.ToBase64String(JsonSerializer.SerializeToUtf8Bytes(tokenPayload));
    }

    private static GoogleTokenPayload ParseGooglePayload(string credential)
    {
        var segments = credential.Split('.');

        if (segments.Length < 2)
        {
            throw new InvalidOperationException("Credential format is invalid.");
        }

        var payloadJson = DecodeBase64Url(segments[1]);
        using var document = JsonDocument.Parse(payloadJson);
        var root = document.RootElement;

        var email = root.TryGetProperty("email", out var emailValue) ? emailValue.GetString() : null;
        var name = root.TryGetProperty("name", out var nameValue) ? nameValue.GetString() : null;
        var sub = root.TryGetProperty("sub", out var subValue) ? subValue.GetString() : null;
        var picture = root.TryGetProperty("picture", out var pictureValue) ? pictureValue.GetString() : null;

        return new GoogleTokenPayload(email, name, sub, picture);
    }

    private static string DecodeBase64Url(string value)
    {
        var padded = value.Replace('-', '+').Replace('_', '/');

        padded = (padded.Length % 4) switch
        {
            2 => padded + "==",
            3 => padded + "=",
            _ => padded
        };

        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(padded));
    }

    private sealed record GoogleTokenPayload(string? Email, string? Name, string? Subject, string? Picture);
}