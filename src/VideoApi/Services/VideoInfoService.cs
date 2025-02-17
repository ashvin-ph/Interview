using System.Text.Json;
using VideoApi.Models;

namespace VideoApi.Services;

public interface IVideoInfoService
{
    Task<Video?> GetVideoInfo(string videoId);
}

public class VideoInfoService : IVideoInfoService
{
    private readonly string? _apiKey;
    private readonly string? _baseUrl;
    private readonly HttpClient _httpClient = new();
    
    public VideoInfoService(IConfiguration configuration)
    {
        _apiKey = configuration["YouTube:ApiKey"];
        _baseUrl = configuration["YouTube:BaseUrl"];
    }
    
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = null
    };

    public async Task<Video?> GetVideoInfo(string videoId)
    {
        var url = $"{_baseUrl}/videos?part=snippet&id={videoId}&key={_apiKey}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var videoResponse = JsonSerializer.Deserialize<VideoResponse>(
            jsonString,
            _jsonSerializerOptions
        );

        if (videoResponse == null || videoResponse.items.Count <= 0) return null;
        
        var externalVideo = videoResponse.items[0];
        var video = new Video(externalVideo);
        return video;
    }
}