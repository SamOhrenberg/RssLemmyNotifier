using System.Text.Json.Serialization;

namespace RssLemmyNotifier.Models.Lemmy;

public class Post
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; } = string.Empty;
}