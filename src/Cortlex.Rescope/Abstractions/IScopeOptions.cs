namespace Cortlex.Rescope.Abstractions
{
    public interface IScopeOptions
    {
        IInjectionScopeFactory InjectionScopeFactory { get; }

        IScopeOptions UseInjectionScopeFactory(IInjectionScopeFactory factory);
    }
}
