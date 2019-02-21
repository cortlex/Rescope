namespace AspNetCore.Web.Autofac.Example.Scopes
{
    public interface IDbScopeFactory
    {
        DbTransactionalScope RequireDbTransactionalScope();
    }
}