namespace AspNetCore.Web.Autofac.Default.Example.Scopes
{
    public interface IDbScopeFactory
    {
        DbTransactionalScope RequireDbTransactionalScope();
    }
}