using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RssLemmyNotifier.Models.Requests;

public class CreatePost
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("community_id")]
    public int CommunityId { get; set; }

    [JsonPropertyName("auth")]
    public string Auth { get; set; }

    public CreatePost(string name, string body, int communityId, string auth)
    {
        Name = name;
        Body = body;
        CommunityId = communityId;
        Auth = auth;
    }
}
