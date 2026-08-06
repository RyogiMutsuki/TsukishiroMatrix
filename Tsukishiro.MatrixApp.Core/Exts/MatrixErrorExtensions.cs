using Tsukishiro.MatrixApp.Core.Models;

namespace Tsukishiro.MatrixApp.Core.Exts;

public static class MatrixErrorExtensions
{
    public static string ToTianyiMessage(this MatrixError error) => error switch
    {
        MatrixError.Forbidden => "锦依卫：禁止通行！",
        MatrixError.NotFound => "花落人断肠，找不到了...",
        MatrixError.LimitReached or MatrixError.ResLimitReached => "吃太快了... 慢一点",
        MatrixError.MissingToken or MatrixError.UnknownToken => "你不是锦依卫！令牌无效",
        MatrixError.Unauthorized => "华风夏韵... 暗号错了",
        MatrixError.BadJson or MatrixError.NotJson => "这盘菜看不懂... JSON 格式错误",
        MatrixError.TooLarge => "太大了，吃货殿下吃不下",
        MatrixError.UserLimitReached => "再吃就要超标了",
        MatrixError.Locked => "殿下被锁在外面了",
        MatrixError.Suspended => "殿下被暂停活动了",
        MatrixError.Unrecognized => "这道菜不在食谱上",
        MatrixError.BadState => "厨房乱套了，状态不对",
        MatrixError.InvalidParam => "这个配方不对",
        MatrixError.MissingParam => "少放了调料，参数不全",
        MatrixError.GuestAccessProhabbited => "访客不能吃席",
        MatrixError.Unknown => "这个错误连吃货都没见过",
        _ => TianyiStatusMessages.ForError()
    };
}
