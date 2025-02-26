using System.Text;
using ImageApi.Services;
using ImageApi.Services.Constants;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace ImageApi.Controllers;

[ApiController]
[Route("/images")]
public class ImageController : Controller
{
    private readonly IImageService ImageService;
    private readonly IConstants constants;
    private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");

    public ImageController(IImageService imageService, IConstants constants)
    {
        ImageService = imageService;
        this.constants = constants;
    }

    [HttpPost("addimage")]
    public async Task<string> AddImage(IFormFile file)
    {
        await Task.Delay(constants.IntervalTime);

        return await ImageService.AddImage(file);
    }

    [HttpGet("{fileName}")]
    public async Task<IActionResult> GetImage(string fileName)
    {
        await Task.Delay(constants.IntervalTime);
        var filePath = Path.Combine(_imagePath, fileName);
        var contentType = GetContentType(filePath);

        //check if in redis
        var conn = ConnectionMultiplexer.Connect(constants.RedisUrl);
        var db = conn.GetDatabase();

        var possibleFile = await db.StringGetAsync(fileName);

        if(possibleFile.HasValue)
        {
            System.Console.WriteLine("I returned something from the redis cache!");
            return File((byte[])possibleFile!, contentType);
        }


        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("Image not found");
        }

        var imageBytes = System.IO.File.ReadAllBytes(filePath);

        await db.StringSetAsync(fileName, imageBytes, expiry: TimeSpan.FromMinutes(5));

        await Task.Delay(constants.IntervalTime);

        return File(imageBytes, contentType);
    }

    private string GetContentType(string path)
    {
        var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(path, out var contentType))
        {
            contentType = "application/octet-stream";
        }
        return contentType;
    }
}
