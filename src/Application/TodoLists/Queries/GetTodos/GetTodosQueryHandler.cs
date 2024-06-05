using Assignment.Application.Common.Interfaces;

namespace Assignment.Application.TodoLists.Queries.GetTodos;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IList<TodoListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<TodoListDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
                .AsNoTracking()
                .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken);
    }
}
