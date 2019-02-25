using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUsernameLookup.Services.Models
{
    public class GitHubRepository
    {
        public string Name { get; set; }

        [JsonProperty("stargazers_count")]
        public int StarGazerCount { get; set; }
    }
}
