using Caliburn.Micro;

namespace Assignment.UI.Features.PopupServices;
internal class DialogService : IDialogService
{
    private readonly IWindowManager _windowManager;

    public DialogService(IWindowManager windowManager)
    {
        _windowManager = windowManager;
    }

    public Task<bool?> ShowError(string message)
    => ShowDialog(message, "Error");

    public Task<bool?> ShowInformation(string message)
    => ShowDialog(message, "Information");

    public Task<bool?> ShowSuccess(string message)
    => ShowDialog(message, "Success");

    private Task<bool?> ShowDialog(string message, string title)
    {
        var dialogViewModel = new MessageDialogViewModel
        {
            Message = message,
            Title = title
        };
        return _windowManager.ShowDialogAsync(dialogViewModel);
    }
}
