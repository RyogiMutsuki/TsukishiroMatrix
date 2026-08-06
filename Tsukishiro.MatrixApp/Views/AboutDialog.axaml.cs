using Avalonia.Controls;
using Tsukishiro.MatrixApp.ViewModels;

namespace Tsukishiro.MatrixApp.Views;

public partial class AboutDialog : Window
{
    public AboutDialog()
    {
        InitializeComponent();
    }

    private void OnOkClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void OnTestError(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button { Tag: string context })
        {
            GetViewModel()?.SetError(context);
        }
    }

    private void OnTestSuccess(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GetViewModel()?.SetSuccess();
    }

    private void OnTestRecipe(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        GetViewModel()?.ShowRandomRecipe();
    }

    private MainWindowViewModel? GetViewModel()
    {
        if (Owner is MainWindow { DataContext: MainWindowViewModel vm })
            return vm;
        return null;
    }
}
