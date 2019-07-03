using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PwnedSharp.Models.HaveIBeenPwned
{
    public class HIBPBreach : IBreach
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        [JsonProperty("PwnedCount")]
        public int PwnedCount { get; set; }
        public DateTime BreachDate { get; set; }
        public bool IsSensitive { get; set; }
        [JsonProperty("LogoPath")]
        public string BrechSiteLogo { get; set; }
        [JsonProperty("DataClasses")]
        public List<string> TypeOfCompromisedInformation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsRetired { get; set; }
        public bool IsSpamList { get; set; }
    }
}
