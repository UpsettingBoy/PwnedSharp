using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharp.Providers
{
    /// <summary>
    /// This abstract class is the base for Pwned API adapters.
    /// </summary>
    internal abstract class PwnedService : IDisposable
    {
        public abstract string AppName { get; set; }

        public PwnedService(string appName)
        {
            AppName = appName;
        }

        public abstract void Dispose();
    }
}
