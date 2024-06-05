namespace Assignment.UI.Features.PopupServices;
public interface IDialogService
{
    Task<bool?> ShowError(string message);
    Task<bool?> ShowInformation(string message);
    Task<bool?> ShowSuccess(string message);
}
