using Assignment.Domain.Entities;

namespace Assignment.Infrastructure.Data.Seeds;
internal static class TodoListSeedExtensions
{
    internal static async Task TryToSeedTodoList(this ApplicationDbContext context)
    {
        if (context.TodoLists.Any())
        {
            return;
        }

        await context.TodoLists.AddAsync(new TodoList
        {
            Title = "Todo List",
            Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
        });

        await context.SaveChangesAsync();
    }
}
