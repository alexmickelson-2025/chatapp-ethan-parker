namespace Api.Services;

public class Constants : IConstants
{
    private string _imageUrl;
    public string ImageUrl => _imageUrl;

    public Constants(IConfiguration config)
    {
        _imageUrl = config.GetValue<string>("IMAGE_API_URL") ?? throw new Exception("Environment variable IMAGE_API_URL");
    }
}