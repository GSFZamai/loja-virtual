namespace BkVirtual.Core.Data;

public interface IUnityOfWork
{
    Task SalvarAlteracoesAsync();
}