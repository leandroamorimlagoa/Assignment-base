﻿using Assignment.Domain.Events;
using Assignment.Domain.Interfaces.CachedRepositories;
using Microsoft.Extensions.Logging;

namespace Assignment.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;
    private readonly ITodoListCachedRepository _todoListCachedRepository;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger
                                        , ITodoListCachedRepository todoListCachedRepository)
    {
        _logger = logger;
        _todoListCachedRepository = todoListCachedRepository;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assignment Domain Event: {DomainEvent}", notification.GetType().Name);

        return _todoListCachedRepository.CleanAllTodoLists();
    }
}
