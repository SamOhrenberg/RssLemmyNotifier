using RssLemmyNotifier.Models;
using RssLemmyNotifier.Models.Lemmy;
using System.ServiceModel.Syndication;

namespace RssLemmyNotifier;

public class RssLemmyService
{
    private readonly LemmyClient _lemmyClient;

    public RssLemmyService(LemmyClient lemmyClient)
    {
        _lemmyClient = lemmyClient;
    }

    public Task<Post> CreateRssPost(FeedToWatch feed, SyndicationItem newItem)
    {
        var episodeNumber = newItem.ElementExtensions.FirstOrDefault(e => e.OuterName.Equals("episode"))?.GetObject<int>();
        var episodeType = newItem.ElementExtensions.FirstOrDefault(e => e.OuterName.Equals("episodeType"))?.GetObject<string>();

        var postTitle = $"[Episode Discussion] [{ (episodeType == "bonus" ? "" : episodeNumber) }] { newItem.Title.Text }";
        var postBody = newItem.Summary.Text;


        return _lemmyClient.CreatePost(postTitle, postBody, feed.CommunityId);
    }
}