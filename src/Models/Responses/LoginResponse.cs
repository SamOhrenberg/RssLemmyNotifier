using System.Text.Json.Serialization;

namespace RssLemmyNotifier.Models.Responses;

public class LoginResponse
{
    [JsonPropertyName("jwt")]
    public string Jwt { get; set; } = string.Empty;

    [JsonPropertyName("registration_created")]
    public bool RegistrationCreated { get; set; }

    [JsonPropertyName("verify_email_sent")]
    public bool VerifyEmailSent { get; set; }
}
