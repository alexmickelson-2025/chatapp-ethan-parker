namespace Api.Services;

public interface IFilePathService
{
    public Task<string?> GetFilePathAsync(IFormFile file);
}