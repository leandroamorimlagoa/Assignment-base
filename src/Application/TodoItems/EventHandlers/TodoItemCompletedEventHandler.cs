using Assignment.Domain.Events;
using Assignment.Domain.Interfaces.CachedRepositories;
using Microsoft.Extensions.Logging;

namespace Assignment.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;
    private readonly ITodoListCachedRepository _todoListCachedRepository;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger
                                            , ITodoListCachedRepository todoListCachedRepository)
    {
        _logger = logger;
        _todoListCachedRepository = todoListCachedRepository;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assignment Domain Event: {DomainEvent}", notification.GetType().Name);

        return _todoListCachedRepository.CleanAllTodoLists();
    }
}
