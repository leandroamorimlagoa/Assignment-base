namespace Assignment.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<int>
{
    public string Title { get; set; } = string.Empty;
    public CreateTodoListCommand(string title)
    {
        Title = title;
    }
}
