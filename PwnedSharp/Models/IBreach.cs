using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharp.Models
{
    public interface IBreach
    {
        string Name { get; }
        string Domain { get; }
        int PwnedCount { get; }
        DateTime BreachDate { get; }
        bool IsSensitive { get; }
        string BrechSiteLogo { get; }
        List<string> TypeOfCompromisedInformation { get; }
        string Description { get; }
    }
}
