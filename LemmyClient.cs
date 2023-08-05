using RestSharp;
using RssLemmyNotifier.Models.Lemmy;
using RssLemmyNotifier.Models.Requests;
using RssLemmyNotifier.Models.Responses;
using System.Text.Json;

namespace RssLemmyNotifier;

public class LemmyClient
{
    private Uri _baseUrl;
    private string _jwt;
    private readonly RestClient _restClient;
    private readonly Task _loggingInTask;

    public LemmyClient(string instanceUrl, string username, string password, string apiVersion)
    {
        _baseUrl = new Uri($"https://{instanceUrl}/api/{apiVersion}/");
        var httpClient = new HttpClient()
        {
            BaseAddress = _baseUrl
        };

        _restClient = new RestClient(httpClient);

        _loggingInTask = LoginAsync(username, password);
    }

    private async Task LoginAsync(string username, string password)
    {
        var loginRequest = new Login(username, password, null);

        var httpRequest = new RestRequest("user/login", Method.Post)
                                .AddJsonBody(loginRequest);

        var restResponse = await _restClient.PostAsync(httpRequest);

        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(restResponse.Content);

        _jwt = loginResponse!.Jwt;
    }

    internal async Task<Post> CreatePost(string name, string body, int communityId)
    {
        await _loggingInTask;

        var createPostParams = new CreatePost(name, body, communityId, _jwt);

        var httpRequest = new RestRequest("post", Method.Post)
                                .AddJsonBody(createPostParams);

        var restResponse = await _restClient.PostAsync(httpRequest);

        var postResponse = JsonSerializer.Deserialize<PostResponse>(restResponse.Content);

        return postResponse.PostView.Post;
    }
}
