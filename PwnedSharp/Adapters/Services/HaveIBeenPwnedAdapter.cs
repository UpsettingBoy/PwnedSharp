using PwnedSharp.Models.HaveIBeenPwned;
using PwnedSharp.Providers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PwnedSharp.Adapters.Services
{
    /// <summary>
    /// Adapter class of HaveIBeenPwned API. <para></para>
    /// </summary>
    internal class HaveIBeenPwnedAdapter : PwnedService
    {
        private const string BASE_ADDRESS = "https://haveibeenpwned.com/api/";
        private const string BASE_PASS_ADDRESS = "https://api.pwnedpasswords.com/range/";
        private const string CURRENT_VERSION = "2";

        private HttpClient _client;
        private HttpClient _passClient;
        private bool _isDisposed = false;

        public override string AppName { get; set; }

        public HaveIBeenPwnedAdapter(string appName) : base(appName)
        {
            AppName = appName;

            _client = new HttpClient
            {
                BaseAddress = new Uri(BASE_ADDRESS)
            };
            _client.DefaultRequestHeaders.Add("api-version", CURRENT_VERSION);
            _client.DefaultRequestHeaders.Add("User-Agent", appName);
        }

        /// <summary>
        /// Gets all the <see cref="HIBPBreach"/> <paramref name="email"/> appears in.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<List<HIBPBreach>> GetBreachesAsync(string email)
        {
            var data = _client.GetStringAsync($"breachedaccount/{email}");
            return JSONConverter.Deserialize<List<HIBPBreach>>(await data);
        }

        /// <summary>
        /// Gets all the <see cref="HIBPBreach"/> stores on the server.
        /// </summary>
        /// <returns></returns>
        public async Task<List<HIBPBreach>> GetAllBreachesAsync()
        {
            var data = _client.GetStringAsync("breaches");
            return JSONConverter.Deserialize<List<HIBPBreach>>(await data);
        }

        /// <summary>
        /// Gets a <see cref="HIBPBreach"/> of the specified <paramref name="site"/>.
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public async Task<HIBPBreach> GetSingleSiteBreach(string site)
        {
            var data = _client.GetStringAsync($"breach/{site}");
            return JSONConverter.Deserialize<HIBPBreach>(await data);
        }

        /// <summary>
        /// Checks if <paramref name="pass"/> has been pwned. <para></para>
        /// The comprobation is based on k-Anonymity model.
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public async Task<bool> CheckPwnedPassAsync(string pass)
        {
            //Lazy initilization of HttpClient for this endpoint.
            if (_passClient is null)
            {
                _passClient = new HttpClient
                {
                    BaseAddress = new Uri(BASE_PASS_ADDRESS)
                };
                _passClient.DefaultRequestHeaders.Add("api-version", CURRENT_VERSION);
                _passClient.DefaultRequestHeaders.Add("User-Agent", AppName);
            }

            HashAlgorithm sha = SHA1.Create();
            byte[] byteHashPasswd = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));

            string hash = BitConverter.ToString(byteHashPasswd).Replace("-", "");

            //Get 5 first HEX digits for k-Anonymity model.
            string first5 = hash.Substring(0, 5);
            string remain = hash.Substring(5);

            var stringData = await _passClient.GetStringAsync($"{first5}");

            foreach (string pwned in stringData.Split('\r', '\n'))
            {
                string hashRemain = pwned.Split(':')[0];

                if (remain == hashRemain)
                    return true;
            }
            
            return false;
        }

        public override void Dispose()
        {
            if (_isDisposed)
                return;

            _client.Dispose();
            _passClient?.Dispose();
        }
    }
}
