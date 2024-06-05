namespace Assignment.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string Title { get; set; } = string.Empty;

    public Colour Colour { get; set; } = Colour.White;

    public ICollection<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
