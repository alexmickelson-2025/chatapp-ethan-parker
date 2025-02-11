using Logic;
using Logic.Requests;

namespace Api.Services;

public interface IMessageService
{
    public Task<List<Message>> GetAllMessages();
    public Task<bool> AddMessage(AddMessageRequest addMessageRequest);
}