using Assignment.Domain.Enums;

namespace Assignment.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Note { get; init; }
    public PriorityLevel Priority { get; set; }

    public CreateTodoItemCommand(int listId, string title, PriorityLevel priority, string? note)
    {
        ListId = listId;
        Title = title;
        Note = note;
        Priority = priority;
    }
}
