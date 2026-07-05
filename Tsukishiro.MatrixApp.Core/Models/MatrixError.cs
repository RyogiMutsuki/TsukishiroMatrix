namespace Tsukishiro.MatrixApp.Core.Models;

/// <summary>
/// Matrix 协议标准错误码
/// 参考：https://spec.matrix.org/latest/client-server-api/#common-error-codes
/// </summary>
public enum MatrixError
{
    /// <summary>
    /// 请求包含有效的 JSON，但格式错误
    /// </summary>
    BadJson,

    /// <summary>
    /// 禁止访问
    /// </summary>
    Forbidden,

    /// <summary>
    /// 短时间内发送了过多请求。
    /// </summary>
    LimitReached,

    /// <summary>
    /// 未提供令牌
    /// </summary>
    MissingToken,

    /// <summary>
    /// 找不到该请求所对应的资源。
    /// </summary>
    NotFound,

    /// <summary>
    /// 请求不包含有效的 JSON。
    /// </summary>
    NotJson,

    /// <summary>
    /// 由于 homeserver 已达到对其施加的资源限制，无法完成请求。
    /// </summary>
    ResLimitReached,

    /// <summary>
    /// 由于用户已超过（或请求将导致其超过）与其账户相关的限制，无法完成请求。
    /// </summary>
    UserLimitReached,

    /// <summary>
    /// 发生了未知错误。
    /// </summary>
    Unknown,

    /// <summary>
    /// 应用服务提供的设备 ID 在身份断言期间不属于该用户 ID。
    /// </summary>
    UnknownDevice,

    /// <summary>
    /// 指定的访问令牌或刷新令牌未被识别。
    /// </summary>
    UnknownToken,

    /// <summary>
    /// 服务器未理解该请求。
    /// </summary>
    Unrecognized,

    /// <summary>
    /// 账户已被锁定，目前无法使用。
    /// </summary>
    Locked,

    /// <summary>
    /// 账户已被暂停，目前仅能执行有限操作。
    /// </summary>
    Suspended,

    /// <summary>
    /// 请求的状态变更无法执行
    /// </summary>
    BadState,

    /// <summary>
    /// 用户无法拒绝加入服务器通知房间的邀请。
    /// </summary>
    CannotLeaveServiceNoticeRoom,

    /// <summary>
    /// 无效的 Captcha 响应。
    /// </summary>
    CaptchaInvalid,

    /// <summary>
    /// 需要 Captcha 验证。
    /// </summary>
    CaptchaNeed,

    /// <summary>
    /// 请求的资源被应用服务保留。
    /// </summary>
    Exclusive,

    /// <summary>
    /// 房间或资源不允许访客访问。
    /// </summary>
    GuestAccessProhabbited,

    /// <summary>
    /// 客户端尝试加入一个服务器不支持其版本的房间。
    /// </summary>
    Incompatible,

    /// <summary>
    /// 指定的参数值错误。例如，服务器期望整数却收到了字符串。
    /// </summary>
    InvalidParam,

    /// <summary>
    /// 在 createRoom API 中提供的初始状态无效。
    /// </summary>
    InvalidRoomState,

    /// <summary>
    /// 无效的用户 ID。
    /// </summary>
    InvalidUserName,

    /// <summary>
    /// 请求缺少必需参数。
    /// </summary>
    MissingParam,

    /// <summary>
    /// 房间别名已被使用。
    /// </summary>
    RoomInUsed,

    /// <summary>
    /// 使用了该服务器不信任的第三方服务器。
    /// </summary>
    ServerNotTrusted,

    /// <summary>
    /// 无法对第三方标识符执行身份验证。
    /// </summary>
    ThreddIdAuthFailed,

    /// <summary>
    /// 不允许此第三方标识符。
    /// </summary>
    ThreeIdServerAuthDenied,

    /// <summary>
    /// 客户端指定的第三方标识符不可接受，因为已在使用中。
    /// </summary>
    ThreeIdInUsed,

    /// <summary>
    /// homeserver 不支持添加给定介质的第三方标识符。
    /// </summary>
    ThreeIdMediumNotSupport,

    /// <summary>
    /// 请求或实体过大。
    /// </summary>
    TooLarge,

    /// <summary>
    /// 请求未正确授权。通常由于登录失败。
    /// </summary>
    Unauthorized,

    /// <summary>
    /// 客户端创建房间的请求使用了服务器不支持的房间版本。
    /// </summary>
    UnsupportRoomVersion,

    /// <summary>
    /// 登录状态失效。
    /// </summary>
    UserDeactived,

    /// <summary>
    /// 尝试注册已被占用的用户 ID。
    /// </summary>
    UserInUsed,
}