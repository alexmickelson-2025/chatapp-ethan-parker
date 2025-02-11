using Api.Services;
using Logic;
using Logic.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/message")]
public class MessageController : Controller
{
    private readonly IMessageService messageService;

    public MessageController(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    [HttpGet("getall")]
    public Task<List<Message>> GetAllMessages()
    {
        return messageService.GetAllMessages();
    }

    [HttpPost("post")]
    public Task<bool> AddMessage([FromBody]AddMessageRequest addMessageRequest)
    {
        return messageService.AddMessage(addMessageRequest);
    }
}