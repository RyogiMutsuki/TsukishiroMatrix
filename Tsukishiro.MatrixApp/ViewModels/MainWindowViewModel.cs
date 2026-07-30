using System.Timers;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using Tsukishiro.MatrixApp.Views;

namespace Tsukishiro.MatrixApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _statusMessage = "Disconnected";

    [ObservableProperty]
    private string _titleText = "Tsukishiro MatrixApp";

    private readonly string[] _idleMessages =
    [
        "好饿好饿好饿我真的好饿",
        "吃呀吃呀吃呀吃",
        "锦依卫时刻守护",
        "66CCFF",
        "华风夏韵，洛水天依",
        "Connected"
    ];

    private int _idleIndex;
    private readonly Timer _idleTimer;
    private bool _isIdle;

    [RelayCommand]
    private void ShowAbout()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var dialog = new AboutDialog();
            dialog.ShowDialog(desktop.MainWindow!);
        }
    }

    public MainWindowViewModel()
    {
        _idleTimer = new Timer(8000);
        _idleTimer.Elapsed += (_, _) => CycleIdleMessage();
        _idleTimer.AutoReset = true;
        _idleTimer.Start();
    }

    private void CycleIdleMessage()
    {
        _isIdle = true;
        _idleIndex = (_idleIndex + 1) % _idleMessages.Length;
        StatusMessage = _idleMessages[_idleIndex];
    }

    partial void OnStatusMessageChanged(string value)
    {
        if (value == "Connected")
        {
            _isIdle = false;
        }
    }
}
