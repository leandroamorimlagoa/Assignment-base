using Assignment.Domain.Entities;

namespace Assignment.Domain.Interfaces.CachedRepositories;
public interface ITodoListCachedRepository
{
    Task CleanAllTodoLists();
    Task<IEnumerable<TodoList>> GetAllTodoLists();
}
