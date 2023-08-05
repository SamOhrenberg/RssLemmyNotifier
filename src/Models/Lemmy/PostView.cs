using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RssLemmyNotifier.Models.Lemmy;

public class PostView
{
    [JsonPropertyName("post")]
    public Post Post { get; set; }
}
