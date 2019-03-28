using System.Collections.Generic;

namespace Cortlex.Rescope.Tests.Setup.Common
{
    class CollectionWrapper<T>
    {
        public IEnumerable<T> Items { get; }

        public CollectionWrapper(IEnumerable<T> items)
        {
            Items = items;
        }
    }
}