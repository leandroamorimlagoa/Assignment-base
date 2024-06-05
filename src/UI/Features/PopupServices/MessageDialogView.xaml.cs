using System.Windows;
using System.Windows.Input;

namespace Assignment.UI.Features.PopupServices;
/// <summary>
/// Interaction logic for MessageDialogView.xaml
/// </summary>
public partial class MessageDialogView : Window
{
    public MessageDialogView()
    {
        InitializeComponent();
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            DialogResult = false;
            Close();
        }
    }
}
