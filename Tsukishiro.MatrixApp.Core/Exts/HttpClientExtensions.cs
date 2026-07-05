namespace Tsukishiro.MatrixApp.Core.Exts;

public static class ObjectExtensions
{
    extension(HttpClient c)
    {
        public HttpClient Also(Action<HttpClient> configFun)
        {
            configFun.Invoke(c);
            return c;
        }
    }
}

