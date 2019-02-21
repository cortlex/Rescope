namespace Cortlex.Rescope.CustomScope.Example
{
    public interface IDbScopeFactory
    {
        IDbTransactionalScope RequireDbTransactionalScope();
        IDbTransactionalScope BeginDbTransactionalScope();
    }
}