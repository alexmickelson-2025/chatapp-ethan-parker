using Api.Data;
using Logic;
using Logic.Requests;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class MessageService : IMessageService
{
    private readonly IDbContextFactory<ChatDbContext> dbContextFactory;
    private readonly IConstants constants;

    public MessageService(IDbContextFactory<ChatDbContext> dbContextFactory, IConstants constants)
    {
        this.dbContextFactory = dbContextFactory;
        this.constants = constants;
    }
    public async Task<bool> AddMessage(AddMessageRequest addMessageRequest)
    {
        await Task.Delay(constants.IntervalTime);

        var context = await dbContextFactory.CreateDbContextAsync();

        var newMessage = new Message()
        {
            Content = addMessageRequest.Content,
            TimePosted = new DateTime(
                            DateTime.Now.Year,
                            DateTime.Now.Month,
                            DateTime.Now.Day,
                            DateTime.Now.Hour,
                            DateTime.Now.Minute,
                            0
            ).ToUniversalTime(),
            Username = addMessageRequest.Username,
            Id = Random.Shared.Next(0, Int32.MaxValue),
            LamportNumber = addMessageRequest.LamportNumber,
            ProcessId = addMessageRequest.ProcessId,
            ImageUrl = addMessageRequest.ImageUrl,
            ImageApiId = addMessageRequest.ImageApiId,
        };

        context.Messages.Add(newMessage);

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Message>> GetAllMessages()
    {
        await Task.Delay(constants.IntervalTime);

        var context = await dbContextFactory.CreateDbContextAsync();

        return (await context.Messages.ToListAsync()).OrderBy(x => Random.Shared.Next()).ToList();
    }
}