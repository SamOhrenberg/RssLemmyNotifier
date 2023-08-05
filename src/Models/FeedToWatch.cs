using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssLemmyNotifier.Models;

public class FeedToWatch
{
    public string Title { get; set; } = string.Empty;
    public string FeedUrl { get; set; } = string.Empty;
    public int CommunityId { get; set; }
}
