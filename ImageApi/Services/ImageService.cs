using ImageApi.Services.Constants;

namespace ImageApi.Services;

public class ImageService : IImageService
{
    private readonly IConstants constants;

    public ImageService(IConstants constants)
    {
        this.constants = constants;
    }

    public async Task<string> AddImage(IFormFile image)
    {
        if (image is null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        var folderPath = Path.Combine("wwwroot", "images");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var fileName = Guid.NewGuid().ToString() + ".png";

        var filePath = Path.Combine(folderPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await Task.Delay(constants.IntervalTime);
            await image.CopyToAsync(stream);
        }

        return fileName;
    }
}
