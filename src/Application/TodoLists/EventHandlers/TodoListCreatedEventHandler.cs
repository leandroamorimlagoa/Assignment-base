using Assignment.Domain.Events;
using Assignment.Domain.Interfaces.CachedRepositories;
using Microsoft.Extensions.Logging;

namespace Assignment.Application.TodoLists.EventHandlers;
public class TodoListCreatedEventHandler : INotificationHandler<TodoListCreatedEvent>
{
    private readonly ILogger<TodoListCreatedEventHandler> _logger;
    private readonly ITodoListCachedRepository _todoListCachedRepository;

    public TodoListCreatedEventHandler(ILogger<TodoListCreatedEventHandler> logger
                                        , ITodoListCachedRepository todoListCachedRepository)
    {
        _logger = logger;
        _todoListCachedRepository = todoListCachedRepository;
    }

    public Task Handle(TodoListCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assignment Domain Event: {DomainEvent}", notification.GetType().Name);
        return _todoListCachedRepository.CleanAllTodoLists();
    }
}
