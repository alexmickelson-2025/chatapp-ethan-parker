using Api.Services;
using Logic;
using Logic.Requests;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/message")]
public class MessageController : Controller
{
    private readonly IMessageService messageService;
    private readonly IFilePathService filePathService;

    public MessageController(IMessageService messageService, IFilePathService filePathService)
    {
        this.messageService = messageService;
        this.filePathService = filePathService;
    }

    [HttpGet("getall")]
    public Task<List<Message>> GetAllMessages()
    {
        return messageService.GetAllMessages();
    }

    [HttpPost("post")]
    public async Task<bool> AddMessage(
                                [FromForm(Name = "username")] string Username, 
                                [FromForm(Name = "content")] string Content, 
                                [FromForm(Name = "lamport_number")] string LamportString, 
                                [FromForm(Name = "process_id")] string ProcessId,
                                [FromForm(Name = "image")] IFormFile? Image)
    {

        var newMessageRequest = new AddMessageRequest()
        {
            Content = Content,
            LamportNumber = int.Parse(LamportString),
            ProcessId = ProcessId,
            Username = Username
        };
        
        if(Image != null)
        {
            var possibleImagePath = await filePathService.GetFilePathAsync(Image);
            if(possibleImagePath != null)
            {
                newMessageRequest.ImageUrl = possibleImagePath;
            }
        }

        return await messageService.AddMessage(newMessageRequest);
    }
}