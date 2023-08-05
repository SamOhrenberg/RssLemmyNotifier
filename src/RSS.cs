using RssLemmyNotifier.Models;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssLemmyNotifier;

public static class RSS
{
public static List<SyndicationItem> GetCurrentFeedItems(FeedToWatch feed)
{
    SyndicationFeed feedDetails = null;

    try
    {
        using var reader = XmlReader.Create(feed.FeedUrl);
        feedDetails = SyndicationFeed.Load(reader);
    }
    catch
    {
        return new List<SyndicationItem>();
    } 

    if (feedDetails is null)
    {
        return new List<SyndicationItem>();
    }

    return feedDetails.Items.OrderByDescending(i => i.PublishDate).ToList();
}
}
