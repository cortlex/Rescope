namespace NETFramework.Web.CastleWindsor.Example.Scopes
{
    public interface IDbScopeFactory
    {
        DbTransactionalScope RequireDbTransactionalScope();
        DbTransactionalScope BeginDbTransactionalScope();
    }
}