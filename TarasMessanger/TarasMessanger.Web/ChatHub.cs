using Microsoft.AspNetCore.SignalR;
using TarasMessanger.Web.Services;
using TarasMessenger.Core.Models.Messages;

namespace TarasMessanger.Web;

public class ChatHub : Hub
{
    private readonly MessageService _messageService;

    public ChatHub(MessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task JoinChat(Guid chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    public async Task LeaveChat(Guid chatId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    public async Task SendMessage(MessageDto dto)
    {
        // 🔹 зберігаємо в БД
        var message = new MessageBase
        {
            Id = Guid.NewGuid(),
            ChatId = dto.ChatId,
            UserId = dto.UserId,
            Text = dto.Text,
            SendAt = DateTime.UtcNow
        };

        await _messageService.AddMessage(message);

        // 🔹 відправляємо всім у чаті
        await Clients.Group(dto.ChatId.ToString())
            .SendAsync("ReceiveMessage", dto);
    }
}