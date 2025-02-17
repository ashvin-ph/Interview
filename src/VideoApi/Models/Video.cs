using System.Globalization;

namespace VideoApi.Models;

public class Video
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishedAt { get; set; }

    public Video(ExternalVideoDto external)
    {
        Id = external.id;
        Title = external.snippet.title;
        Description = external.snippet.description;

        PublishedAt = DateTime.ParseExact("yyyy-mm-ddThh:mm:ss", external.snippet.publishedAt, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }
}