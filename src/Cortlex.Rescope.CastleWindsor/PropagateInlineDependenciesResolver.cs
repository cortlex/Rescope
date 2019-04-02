using System;
using System.Reflection;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Resolvers;

namespace Cortlex.Rescope.CastleWindsor
{
    public class PropagateInlineDependenciesResolver: DefaultDependencyResolver
    {
        protected override CreationContext RebuildContextForParameter(CreationContext current, Type parameterType)
        {
            if (parameterType.GetTypeInfo().ContainsGenericParameters)
                return current;

            return new CreationContext(parameterType, current, true);
        }
    }
}
