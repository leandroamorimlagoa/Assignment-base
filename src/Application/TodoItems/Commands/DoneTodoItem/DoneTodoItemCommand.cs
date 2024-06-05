namespace Assignment.Application.TodoItems.Commands.DoneTodoItem;

public record DoneTodoItemCommand : IRequest
{
    public int Id { get; init; }
    public DoneTodoItemCommand(int id)
    {
        Id = id;
    }
}
