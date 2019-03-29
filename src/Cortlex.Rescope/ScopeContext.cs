using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Cortlex.Rescope
{
    internal class ScopeContext
    {
        private static readonly ConcurrentDictionary<string, AsyncLocal<Guid?>> _callContext = new ConcurrentDictionary<string, AsyncLocal<Guid?>>();

        public void SetData(string name, Guid? data)
        {
            _callContext.AddOrUpdate(name, (key) => new AsyncLocal<Guid?> { Value = data }, (s, local) =>
            {
                local.Value = data;
                return local;
            });
        }

        public Guid? GetData(string name)
        {
            return _callContext.TryGetValue(name, out AsyncLocal<Guid?> data) ? data.Value : (Guid?)null;
        }
    }
}
