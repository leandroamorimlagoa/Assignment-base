using Assignment.Application.Common.Security;

namespace Assignment.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<IList<TodoListDto>>;
