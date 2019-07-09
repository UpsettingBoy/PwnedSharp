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

        /// <summary>
        /// Gets the only instance of <see cref="PwnedFactory"/>.
        /// </summary>
        public static PwnedFactory Instance => _instance.Value;

        private static readonly Lazy<PwnedFactory> _instance = new Lazy<PwnedFactory>(() => new PwnedFactory());
        private static string _appName = DEFAULT_APPNAME;

        private readonly Dictionary<ProvidersEnum, IPwnedService> _providers;

        private PwnedFactory()
        {
            _providers = new Dictionary<ProvidersEnum, IPwnedService>();
        }

        /// <summary>
        /// Sets the default name of the app.
        /// </summary>
        /// <param name="name"></param>
        public void SetDefaultAppName(string name)
        {
            _appName = name ?? DEFAULT_APPNAME;
        }

        /// <summary>
        /// Gets an instance of <see cref="IPwnedService"/>.<para></para>
        /// If <paramref name="appName"/> is not setted, <see cref="DEFAULT_APPNAME"/> will be used.<para></para>
        /// If <see cref="SetDefaultAppName(string)"/> was used, better use the indexer <see cref="this[ProvidersEnum]"/>.
        /// </summary>
        /// <param name="provider"><see cref="IPwnedService"/> provider.</param>
        /// <param name="appName">Name of the app.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the instance linked to <paramref name="provider"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public IPwnedService this[ProvidersEnum provider] => GetPwnedService(provider);
    }
}
