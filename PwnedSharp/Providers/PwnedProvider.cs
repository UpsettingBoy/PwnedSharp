using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharp.Providers
{
    /// <summary>
    /// Abstract class defining the contructor of Pwned providers.
    /// </summary>
    public abstract class PwnedProvider : IDisposable
    {
        public PwnedProvider(string appName)
        { }

        public abstract void Dispose();
    }
}
