using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharp.Providers
{
    public abstract class PwnedService : IDisposable
    {
        public abstract string AppName { get; set; }

        public PwnedService(string appName)
        {
            AppName = appName;
        }

        public abstract void Dispose();
    }
}
