namespace Assignment.Domain.Events;
public class TodoListCreatedEvent : BaseEvent
{
    public TodoListCreatedEvent(TodoList list)
    {
        List = list;
    }

    public TodoList List { get; }
}
