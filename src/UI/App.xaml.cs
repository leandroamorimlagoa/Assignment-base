using System.Text;
using System.Windows;
using Assignment.Application.Common.Exceptions;

namespace Assignment.UI;

public partial class App : System.Windows.Application
{
    private void DispatchUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        var errorMessage = HandleException(e.Exception);
        e.Handled = true;
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
