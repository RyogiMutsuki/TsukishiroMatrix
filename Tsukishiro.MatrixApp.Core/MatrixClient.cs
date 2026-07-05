namespace Tsukishiro.MatrixApp.Core;

public class MatrixClient
{
    private HttpClient _client;

    public MatrixClient(string homeServer)
    {
        _client = new HttpClient(
            new SocketsHttpHandler
            {
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(15),
                PooledConnectionLifetime = TimeSpan.FromMinutes(30)
            }
        );
    }

    //public async Task
    
}