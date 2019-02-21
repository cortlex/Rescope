namespace NETCore.GenericHost.CoreDI.Example.Scopes
{
    public interface IDbScopeFactory
    {
        DbTransactionalScope RequireDbTransactionalScope();
        DbTransactionalScope BeginDbTransactionalScope();
    }
}