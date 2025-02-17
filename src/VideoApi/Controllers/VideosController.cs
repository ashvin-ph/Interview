using Microsoft.AspNetCore.Mvc;
using VideoApi.Services;

namespace VideoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideosController : ControllerBase
{
    private readonly IVideoInfoService _videoInfoService;

    public VideosController(IVideoInfoService videoInfoService)
    {
        _videoInfoService = videoInfoService;
    }

    // GET: /api/videos/{videoId}
    [HttpGet("{videoId}")]
    public async Task<IActionResult> GetVideo(string videoId)
    {
        var videoInfo = await _videoInfoService.GetVideoInfo(videoId);

        return videoInfo != null 
            ? Ok(videoInfo) 
            : NotFound();
    }
}