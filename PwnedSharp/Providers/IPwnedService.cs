using PwnedSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PwnedSharp.Providers
{
    public interface IPwnedService : IDisposable
    {
        /// <summary>
        /// Gets all the breaches stored on the API.
        /// </summary>
        /// <returns></returns>
        Task<List<IBreach>> GetAllBreaches();

        /// <summary>
        /// Gets all the breaches this email appears in.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<List<IBreach>> GetBreaches(string email);

        /// <summary>
        /// Gets the breach of a single site.
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        Task<IBreach> GetBreachFromSite(string site);

        /// <summary>
        /// Checks whether <paramref name="passwd"/> is pwned.
        /// </summary>
        /// <param name="passwd"></param>
        /// <returns></returns>
        Task<bool> CheckPwnedPassword(string passwd);
    }
}
