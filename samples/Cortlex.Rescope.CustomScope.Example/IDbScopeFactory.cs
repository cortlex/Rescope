namespace Cortlex.Rescope.CustomScope.Example
{
    public interface IDbScopeFactory
    {
        IDbTransactionalScope RequireDbTransactionalScope(string tagName = DbScopeFactory.DefaultScopeTag);
    }
}