﻿using Assignment.Domain.Entities;

namespace Assignment.Application.TodoLists.Queries.GetTodos;

public class TodoListDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Colour { get; init; }

    public IList<TodoItemDto> Items { get; init; } = new List<TodoItemDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, TodoListDto>();
            CreateMap<TodoItem, TodoItemDto>();
        }
    }
}
