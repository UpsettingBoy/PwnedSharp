using PwnedSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PwnedSharp.Providers
{
    public interface IPwnedService : IDisposable
    {
        Task<List<IBreach>> GetAllBreaches();

        Task<List<IBreach>> GetBreaches(string email);

        Task<IBreach> GetBreachFromSite(string site);

        Task<bool> CheckPwnedPassword(string passwd);
    }
}
