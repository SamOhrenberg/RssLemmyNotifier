using RssLemmyNotifier.Models.Lemmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RssLemmyNotifier.Models.Responses;

public class PostResponse
{
    [JsonPropertyName("post_view")]
    public PostView PostView { get; set; }
}