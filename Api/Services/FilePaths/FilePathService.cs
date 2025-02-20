
using Microsoft.AspNetCore.Identity;

namespace Api.Services;

public class FilePathService : IFilePathService
{
    private readonly IConstants constants;
    private readonly IHttpClientFactory httpClientFactory;

    public FilePathService(IConstants constants, IHttpClientFactory httpClientFactory)
    {
        this.constants = constants;
        this.httpClientFactory = httpClientFactory;
    }


    public async Task<string?> GetFilePathAsync(IFormFile file, int imageApiId)
    {
        var httpClient = httpClientFactory.CreateClient();

        using var content = new MultipartFormDataContent();

        await using var fileStream = file.OpenReadStream();
        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

        content.Add(fileContent, "file", file.FileName);

        var response = await httpClient.PostAsync(constants.ImageUrls[imageApiId - 1] + "/image/addImage", content);

        await Task.Delay(constants.IntervalTime);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return null;

    }
}
