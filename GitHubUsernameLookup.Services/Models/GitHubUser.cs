using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUsernameLookup.Services.Models
{
    public class GitHubUser
    {
        [JsonProperty("login")]
        public string Username { get; set; }
        public string Location { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
