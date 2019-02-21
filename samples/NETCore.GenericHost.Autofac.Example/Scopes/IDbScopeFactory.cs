namespace NETCore.GenericHost.Autofac.Example.Scopes
{
    public interface IDbScopeFactory
    {
        DbTransactionalScope RequireDbTransactionalScope();
        DbTransactionalScope BeginDbTransactionalScope();
    }
}