namespace Tsukishiro.MatrixApp.Core.Models;

public static class TianyiStatusMessages
{
    public static string ForSuccess() => Pick(
        "吃的那双眼都发亮 ✦",
        "华风夏韵，洛水天依",
        "66CCFF ✦",
        "唯席上千年丰盛永不变"
    );

    public static string ForError(string? context = null) => context?.ToLowerInvariant() switch
    {
        "404" or "not_found" or "notfound" => Pick(
            "花落人断肠，找不到了...",
            "唯席上... 咦？不见了",
            "吃货殿下没找到这个"
        ),
        "403" or "forbidden" => Pick(
            "锦依卫：禁止通行！",
            "你不是锦依卫！不能进去",
            "此路不通，换个方向吧"
        ),
        "500" or "server_error" => Pick(
            "亘古滔滔转眼间，服务器不见了...",
            "天钿迷失在精灵乡了",
            "服务器饿晕了，等会儿再来"
        ),
        "timeout" => Pick(
            "想太多还不如什么都别想... 超时了",
            "等太久了，天依都饿了",
            "再不来我就去吃饭了 ⏰"
        ),
        "connection" or "disconnected" => Pick(
            "连接断了... 好饿好饿",
            "天钿找不到信号了",
            "网络仿佛被吃掉了"
        ),
        "empty" or "no_data" => Pick(
            "好饿好饿好饿，什么都没有",
            "空空如也，像被吃完的盘子",
            "这里比我的钱包还干净"
        ),
        "auth" or "unauthorized" => Pick(
            "你不是锦依卫！身份验证失败",
            "口令不对，再来一次？",
            "华风夏韵... 暗号错了"
        ),
        "rate_limit" or "too_many" => Pick(
            "吃太快了... 慢一点",
            "别急别急，一个一个来",
            "再快就要噎着了"
        ),
        _ => Pick(
            "花落人断肠，出错了...",
            "发生了什么？天依也不知道",
            "这个错误连吃货都没见过"
        )
    };

    public static string ForLoading() => Pick(
        "吃呀吃呀吃呀吃...",
        "正在烹饪中...",
        "天钿正在努力加载"
    );

    public static string ForRetry() => Pick(
        "一起奋斗吧！再试一次",
        "再来一碗！重试中",
        "不屈不挠，吃货精神"
    );

    public static string ForOffline() => Pick(
        "殿下要去觅食了，离线中",
        "天依去吃饭了，一会儿回来",
        "离线模式：只有千年食谱颂相伴"
    );

    private static string Pick(params string[] messages)
        => messages[Random.Shared.Next(messages.Length)];
}
