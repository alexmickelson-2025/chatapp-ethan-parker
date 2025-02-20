namespace ImageApi.Services;

public interface IImageService
{
    public Task<string> AddImage(IFormFile image);
}
