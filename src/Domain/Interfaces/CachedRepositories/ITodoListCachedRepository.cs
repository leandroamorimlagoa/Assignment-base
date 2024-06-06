namespace Assignment.Domain.Interfaces.CachedRepositories;
public interface ITodoListCachedRepository
{
    Task<IEnumerable<TodoList>> GetAllTodoLists();
}
