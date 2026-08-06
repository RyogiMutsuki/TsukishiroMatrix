using System.Threading.Tasks;
using System.Timers;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Tsukishiro.MatrixApp.Core.Models;
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

    [ObservableProperty]
    private string _inputText = "";

    public bool IsBirthday { get; }
    public string BirthdayGreeting => "🎂 洛天依生日快乐！🎵";

    private readonly string[] _idleMessages =
    [
        TianyiStatusMessages.ForLoading(),
        "锦依卫时刻守护",
        "66CCFF ✦",
        "华风夏韵，洛水天依",
        "Connected"
    ];

    private int _idleIndex;
    private readonly Timer _idleTimer;
    private bool _isIdle;

    private static readonly string[] _recipeLyrics =
    [
        "小笼包 叉烧包 奶黄芝麻豆沙包",
        "大碗炸酱面 热乎乎的吃不够",
        "火锅底料蘸料 一样都不能少",
        "糖醋里脊 外酥里嫩 酸甜刚好",
        "北京烤鸭 卷饼吃 香脆又美味",
        "麻婆豆腐 麻辣鲜香 入口即化",
        "红烧肉 肥而不腻 入口即化",
        "兰州拉面 汤清面劲 牛肉飘香",
        "煎饼果子 来一套 鸡蛋薄脆加辣条",
        "串串香 麻辣烫 冒菜火锅 一个都不能少",
        "好饿好饿好饿 我真的好饿",
        "吃呀吃呀吃呀 我们一起吃"
    ];

    [RelayCommand]
    private void SendMessage()
    {
        var text = InputText.Trim();
        if (string.IsNullOrEmpty(text)) return;

        if (text.Equals("/recipe", StringComparison.OrdinalIgnoreCase))
        {
            ShowRandomRecipe();
        }
        else if (text.Contains("#66CCFF", StringComparison.OrdinalIgnoreCase))
        {
            Trigger66CCFF();
        }

        InputText = "";
    }

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

    public void ShowRandomRecipe()
    {
        var rng = Random.Shared.Next(_recipeLyrics.Length);
        StatusMessage = "🍜 " + _recipeLyrics[rng];
    }

    public void SetError(string context)
    {
        StatusMessage = TianyiStatusMessages.ForError(context);
        IsFlashActive = true;
        Task.Delay(600).ContinueWith(_ =>
            Dispatcher.UIThread.Post(() => IsFlashActive = false));
    }

    public void SetLoading()
    {
        StatusMessage = TianyiStatusMessages.ForLoading();
    }

    public void SetSuccess()
    {
        StatusMessage = TianyiStatusMessages.ForSuccess();
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
