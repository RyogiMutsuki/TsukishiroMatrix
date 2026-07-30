using System.Threading.Tasks;
using System.Timers;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Tsukishiro.MatrixApp.Views;

namespace Tsukishiro.MatrixApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _statusMessage = "Disconnected";

    [ObservableProperty]
    private string _titleText = "Tsukishiro MatrixApp";

    [ObservableProperty]
    private bool _isFlashActive;

    public bool IsBirthday { get; }
    public string BirthdayGreeting => "🎂 洛天依生日快乐！🎵";

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
        var today = DateTime.Today;
        IsBirthday = today.Month == 7 && today.Day == 12;
        if (IsBirthday)
        {
            TitleText = "🎂 洛天依生日快乐！🎵";
        }

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

    public void Trigger66CCFF()
    {
        IsFlashActive = true;
        StatusMessage = "66CCFF ✦";
        Task.Delay(800).ContinueWith(_ =>
        {
            Avalonia.Threading.Dispatcher.UIThread.Post(() => IsFlashActive = false);
        });
    }

    partial void OnStatusMessageChanged(string value)
    {
        if (value == "Connected")
        {
            _isIdle = false;
        }
    }
}
