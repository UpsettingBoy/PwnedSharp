using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharp.Providers
{
    public abstract class PwnedProvider : IDisposable
    {
        public PwnedProvider(string appName)
        { }

        public abstract void Dispose();
    }
}
