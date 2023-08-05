using RssLemmyNotifier;
using RssLemmyNotifier.Models;
using System.ServiceModel.Syndication;
using System.Text.Json;

var feeds = new FeedToWatch[]
{
    new FeedToWatch {
        Title = "ANMA",
        FeedUrl = "https://feeds.megaphone.fm/anma",
        CommunityId = 71337
    },
    new FeedToWatch {
        Title = "F**kFace",
        FeedUrl = "https://feeds.megaphone.fm/fface",
        CommunityId = 4651
    }
};

Dictionary<string, string> settings;

using (var fs = new FileStream("appsettings.json", FileMode.Open))
{
    settings = JsonSerializer.Deserialize<Dictionary<string, string>>(fs);
}

var lemmyClient = new LemmyClient(settings["LemmyInstanceHost"], settings["UserName"], settings["Password"], settings["LemmyApiVersion"]);
var lemmyNotifier = new RssLemmyService(lemmyClient);

var updateMode = settings["UpdateMode"] is not null && settings["UpdateMode"].Equals("true");

foreach (var feed in feeds)
{
    var cachedItems = Cache.GetFeed(feed);
    var rssItems = RSS.GetCurrentFeedItems(feed);
    SyndicationItem newItem = null;

    foreach (var item in rssItems)
    {
        // find first item that isn't in the cachedItems to see if there is a new episode
        if (!cachedItems.ContainsKey(item.Id))
        {
            newItem = item;
            break;
        }
    }

    // we only continue if there is a new episode
    if (newItem == null)
    {
        continue;
    }

    // now we will create the post on the lemmy community
    try
    {
        if (updateMode)
        {
            var post = await lemmyNotifier.CreateRssPost(feed, newItem);
        }

        // update the cache only if there isn't an error from the above
        Cache.SaveFeed(feed, rssItems);
    }
    catch
    {

    }
}
