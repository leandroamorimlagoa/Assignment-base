using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities;
using Assignment.Domain.Interfaces.CachedRepositories;
using Assignment.Infrastructure.CacheEngines;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.Data.CachedRepositories;
public class TodoListCachedRepository : ITodoListCachedRepository
{
    private readonly IApplicationDbContext _dbContext;
    private readonly MemoryCache<List<TodoList>> _cache;

    public TodoListCachedRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _cache = new();
    }

    public async Task<IEnumerable<TodoList>> GetAllTodoLists()
    {
        if (_cache.TryGetValue("TodoLists", out var todoLists) && todoLists != null)
        {
            return todoLists;
        }

        todoLists = await _dbContext.TodoLists
            .OrderBy(t => t.Title)
            .Include(t => t.Items)
            .ToListAsync();

        _cache.Set("TodoLists", todoLists, TimeSpan.FromMinutes(5));

        return todoLists;
    }
}
