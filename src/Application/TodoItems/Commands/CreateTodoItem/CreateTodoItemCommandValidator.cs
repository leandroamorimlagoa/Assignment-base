using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Constants;

namespace Assignment.Application.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    private readonly IApplicationDbContext _context;
    private record BriefTodoItem(int ListId, string? Title);

    public CreateTodoItemCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Title)
            .MaximumLength(FieldsConfigurations.MaxLengthTitleFields)
            .NotEmpty();

        RuleFor(v => new BriefTodoItem(v.ListId, v.Title))
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");

        _context = context;
    }

    private async Task<bool> BeUniqueTitle(BriefTodoItem todoItem, CancellationToken cancellationToken)
    {
        return !await _context.TodoItems
                                .AnyAsync(i => i.ListId == todoItem.ListId && EF.Functions.Like(i.Title, todoItem.Title), cancellationToken);
    }
}
