using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Interfaces.CachedRepositories;

namespace Assignment.Application.TodoLists.Queries.GetTodos;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IList<TodoListDto>>
{
    private readonly ITodoListCachedRepository _todoListCachedRepository;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(ITodoListCachedRepository  todoListCachedRepository, IMapper mapper)
    {
        _todoListCachedRepository = todoListCachedRepository;
        _mapper = mapper;
    }

    public async Task<IList<TodoListDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var todoLists = await _todoListCachedRepository.GetAllTodoLists();

        var result = _mapper.Map<IList<TodoListDto>>(todoLists);
        return result;
    }
}
