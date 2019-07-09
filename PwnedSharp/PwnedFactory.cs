using PwnedSharp.Providers;
using PwnedSharp.Providers.Services;
using System;
using System.Collections.Generic;

namespace PwnedSharp
{
    /// <summary>
    /// Factory of <see cref="IPwnedService"/>.
    /// </summary>
    public class PwnedFactory
    {
        private const string DEFAULT_APPNAME = "PwnedSharp";

        public static PwnedFactory Instance => _instance.Value;

        private static readonly Lazy<PwnedFactory> _instance = new Lazy<PwnedFactory>(() => new PwnedFactory());
        private static string _appName = DEFAULT_APPNAME;

        private readonly Dictionary<ProvidersEnum, IPwnedService> _providers;

        private PwnedFactory()
        {
            _providers = new Dictionary<ProvidersEnum, IPwnedService>();
        }

        public void SetDefaultAppName(string name)
        {
            _appName = name ?? DEFAULT_APPNAME;
        }

        public IPwnedService GetPwnedService(ProvidersEnum provider, string appName = null)
        {
            if (_providers.TryGetValue(provider, out IPwnedService pwned))
                return pwned;

            switch (provider)
            {
                case ProvidersEnum.HaveIBeenPwned:
                    pwned = new HaveIBeenPwned(appName?? _appName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(provider), provider, "Argument out of scope!");
            }

            _providers.Add(provider, pwned);

            return pwned;
        }

        public IPwnedService this[ProvidersEnum provider] => GetPwnedService(provider);
    }
}
