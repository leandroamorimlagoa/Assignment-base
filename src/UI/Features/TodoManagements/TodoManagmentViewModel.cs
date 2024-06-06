using System.Windows.Input;
using Assignment.Application.TodoItems.Commands.DoneTodoItem;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.UI.Features.TodoItems;
using Assignment.UI.Features.TodoLists;
using Assignment.UI.Helpers;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI.Features.TodoManagements;
public class TodoManagmentViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IWindowManager _windowManager;

    private IList<TodoListDto> todoLists;
    public IList<TodoListDto> TodoLists
    {
        get
        {
            return todoLists;
        }
        set
        {
            todoLists = value;
            NotifyOfPropertyChange(() => TodoLists);
        }
    }

    private TodoListDto _selectedTodoList;
    public TodoListDto SelectedTodoList
    {
        get => _selectedTodoList;
        set
        {
            _selectedTodoList = value;
            NotifyOfPropertyChange(() => SelectedTodoList);
            CanAddTodoItem = _selectedTodoList != null && _selectedTodoList.Id > 0;
        }
    }

    private bool _canAddTodoItem;
    public bool CanAddTodoItem
    {
        get => _canAddTodoItem;
        set
        {
            _canAddTodoItem = value;
            NotifyOfPropertyChange(() => CanAddTodoItem);
        }
    }

    private TodoItemDto _selectedItem;
    public TodoItemDto SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            NotifyOfPropertyChange(() => SelectedItem);
            CanFinishTodoItem = _selectedItem != null && _selectedItem.Id > 0 && !_selectedItem.Done;
        }
    }

    private bool _canFinishTodoItem;
    public bool CanFinishTodoItem
    {
        get => _canFinishTodoItem;
        set
        {
            _canFinishTodoItem = value;
            NotifyOfPropertyChange(() => CanFinishTodoItem);
        }
    }

    public ICommand AddTodoListCommand { get; private set; }
    public ICommand AddTodoItemCommand { get; private set; }
    public ICommand DoneTodoItemCommand { get; private set; }

    public TodoManagmentViewModel(ISender sender, IWindowManager windowManager)
    {
        _sender = sender;
        _windowManager = windowManager;
        Initialize();
    }

    private async void Initialize()
    {
        await RefereshTodoLists();

        AddTodoListCommand = new RelayCommand(AddTodoList);
        AddTodoItemCommand = new RelayCommand(AddTodoItem);
        DoneTodoItemCommand = new RelayCommand(DoneTodoItem);
    }

    public async Task RefereshTodoLists()
    {
        var selectedListId = SelectedTodoList?.Id;

        TodoLists = await _sender.Send(new GetTodosQuery());

        if (selectedListId.HasValue && selectedListId.Value > 0)
        {
            SelectedTodoList = TodoLists.FirstOrDefault(list => list.Id == selectedListId.Value);
        }
    }

    private async void AddTodoList(object obj)
    {
        var todoList = new TodoListViewModel(_sender);
        var result = await _windowManager.ShowDialogAsync(todoList);
        if (result.HasValue && result.Value)
        {
            await RefereshTodoLists();
        }
    }

    private async void AddTodoItem(object obj)
    {
        var todoItem = new TodoItemViewModel(_sender, SelectedTodoList.Id);
        var result = await _windowManager.ShowDialogAsync(todoItem);
        if (result.HasValue && result.Value)
        {
            await RefereshTodoLists();
        }
    }

    private async void DoneTodoItem(object obj)
    {
        await _sender.Send(new DoneTodoItemCommand(SelectedItem.Id));
        await RefereshTodoLists();
    }
}
