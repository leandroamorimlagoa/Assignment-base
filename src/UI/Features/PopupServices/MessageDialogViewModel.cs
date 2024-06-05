using Caliburn.Micro;

namespace Assignment.UI.Features.PopupServices;
public class MessageDialogViewModel : Screen
{
    private string _message;
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            NotifyOfPropertyChange(() => Message);
        }
    }

    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            NotifyOfPropertyChange(() => Title);
        }
    }

    public void Ok()
    {
        TryCloseAsync(true);
    }
}
