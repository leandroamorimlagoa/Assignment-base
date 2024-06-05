using Assignment.Domain.Enums;

namespace Assignment.Application.TodoLists.Queries.GetTodos;

public class TodoItemDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string Title { get; init; } = string.Empty;

    public bool Done { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}
