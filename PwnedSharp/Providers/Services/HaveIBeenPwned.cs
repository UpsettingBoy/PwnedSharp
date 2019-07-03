using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PwnedSharp.Models;
using PwnedSharp.Adapters.Services;
using System.Linq;

namespace PwnedSharp.Providers.Services
{
    /// <summary>
    /// HaveIBeenPwned service (wrapper over <see cref="HaveIBeenPwnedAdapter"/>).
    /// </summary>
    internal class HaveIBeenPwned : PwnedProvider, IPwnedService
    {
        private HaveIBeenPwnedAdapter _adapter;

        public HaveIBeenPwned(string appName) : base(appName)
        {
            _adapter = new HaveIBeenPwnedAdapter(appName);
        }

        public Task<bool> CheckPwnedPassword(string passwd)
        {
            return _adapter.CheckPwnedPassAsync(passwd);
        }

        public async Task<List<IBreach>> GetAllBreaches()
        {
            return (await _adapter.GetAllBreachesAsync()).Cast<IBreach>().ToList();
        }

        public async Task<IBreach> GetBreachFromSite(string site)
        {
            return await _adapter.GetSingleSiteBreach(site);
        }

        public async Task<List<IBreach>> GetBreaches(string email)
        {
            return (await _adapter.GetBreachesAsync(email)).Cast<IBreach>().ToList();
        }

        public void Dispose()
        {
            _adapter.Dispose();
        }
    }
}
