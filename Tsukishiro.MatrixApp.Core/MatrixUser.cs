namespace Tsukishiro.MatrixApp.Core;

public class MatrixUser
{

    private const string DefaultMatrixHomeServer = "matrix.org";

    

    /// <summary>
    /// 用户家服务器
    /// </summary>
    /// <returns></returns>
    public required string HomeServer { get; set; }

    public async Task GetLoginMethodAsync()
    {
        
    }

    public async Task LoginAsync(string homeServer = "")
    {
        if (string.IsNullOrWhiteSpace(homeServer)) homeServer = DefaultMatrixHomeServer;

    }

    public async Task LoginAsyncCallback()
    {
        
    }
}
