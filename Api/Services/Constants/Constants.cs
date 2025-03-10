namespace Api.Services;

public class Constants : IConstants
{
    private string[] _imageUrl;
    public string[] ImageUrls => _imageUrl;
    private int _intervalTime;
    public int IntervalTime => _intervalTime;

    public Constants(IConfiguration config)
    {
        _imageUrl = config.GetValue<string>("IMAGE_API_URLS")?.Split(';') ?? throw new Exception("Environment variable IMAGE_API_URL");
        _intervalTime = config.GetValue<int?>("INTERVAL_TIME") ?? 0;
    }
}