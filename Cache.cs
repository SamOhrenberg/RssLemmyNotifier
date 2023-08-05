using RssLemmyNotifier.Models;
using System.ServiceModel.Syndication;
using System.Text.Json;

namespace RssLemmyNotifier;

public static class Cache
{
    static Cache()
    {
        Directory.CreateDirectory("cache");
    }

    public static Dictionary<string, CacheItem> GetFeed(FeedToWatch feed)
    {
        string localFeedPath = GetCachePath(feed);

        if (!File.Exists(localFeedPath))
        {
            return new Dictionary<string, CacheItem>();
        }

        var source = File.ReadAllText(localFeedPath);
        if (string.IsNullOrEmpty(source))
        {
            return new Dictionary<string, CacheItem>();
        }

        var cachedItems = JsonSerializer.Deserialize<List<CacheItem>>(source);
        if (cachedItems is null || cachedItems.Count == 0)
        {
            return new Dictionary<string, CacheItem>();
        }

        return cachedItems.ToDictionary(i => i.Id);
    }

    public static void SaveFeed(FeedToWatch feed, List<SyndicationItem> rssItems)
    {
        string localFeedPath = GetCachePath(feed);

        var cacheItems = rssItems.Select(i => new CacheItem { Id = i.Id });

        File.WriteAllText(localFeedPath, JsonSerializer.Serialize(cacheItems));

    }

    private static string GetCachePath(FeedToWatch feed)
    {
        return Path.Join(Environment.CurrentDirectory, "cache", $"{RemoveInvalidChars(feed.Title)}.json");
    }

    private static string RemoveInvalidChars(string filename)
    {
        return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
    }
}
