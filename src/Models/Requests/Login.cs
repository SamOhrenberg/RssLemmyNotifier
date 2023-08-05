using System.Text.Json.Serialization;

namespace RssLemmyNotifier.Models.Requests;

public class Login
{
    [JsonPropertyName("username_or_email")]
    public string UsernameOrEmail { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("totp_2fa_token")]
    public string Totp2faToken { get; set; } = string.Empty;

    public Login(string usernameOrEmail, string password, string totp2faToken)    {
        UsernameOrEmail = usernameOrEmail;
        Password = password;
        Totp2faToken = totp2faToken;
    }

}
