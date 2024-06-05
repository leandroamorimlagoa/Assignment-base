using System.Text;
using Assignment.Application.Common.Exceptions;
using Assignment.UI.Features.PopupServices;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.UI;

public partial class App : System.Windows.Application
{
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
        _serviceProvider = Bootstrapper.ServiceProvider;
    }

    private void DispatchUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        var errorMessage = HandleException(e.Exception);
        e.Handled = true;
        var dialogService = _serviceProvider.GetService<IDialogService>();
        dialogService.ShowError(errorMessage);
    }

    private string HandleException(Exception exception)
    {
        var messageError = new StringBuilder();
        if (exception is ValidationException validationException)
        {
            foreach (var error in validationException.Errors)
            {
                messageError.AppendLine($"- {error.Value.FirstOrDefault()}");
            }
        }
        else
        {
            messageError.AppendLine(exception.Message);
            if (exception.InnerException != null)
            {
                messageError.AppendLine($"{exception.InnerException.Message}");
            }
        }

        return messageError.ToString();
    }
}
