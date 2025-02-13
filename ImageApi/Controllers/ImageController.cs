using ImageApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageApi.Controllers;

[ApiController]
[Route("/image")]
public class ImageController : Controller
{
    private readonly IImageService ImageService;

    public ImageController(IImageService imageService)
    {
        ImageService = imageService;
    }

    [HttpPost("addimage")]
    public async Task<string> AddImage(IFormFile file)
    {
        return await ImageService.AddImage(file);
    }
}
