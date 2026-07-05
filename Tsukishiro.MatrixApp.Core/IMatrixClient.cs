namespace Tsukishiro.MatrixApp.Core;

public interface IMatrixClient
{
    public Task LocateMatrixServerAsync();
}