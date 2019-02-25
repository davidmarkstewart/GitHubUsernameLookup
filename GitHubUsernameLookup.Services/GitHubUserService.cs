using GitHubUsernameLookup.Services.Common;
using GitHubUsernameLookup.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUsernameLookup.Services
{
    public class GitHubUserService
    {
        private const string GET_USER_DETAILS = "https://api.github.com/users/{0}";

        public async Task<GitHubUser> GetUserDetails(string username)
        {
            var restApiService = new RestApiService();

            var response = await restApiService.GetAsync(string.Format(GET_USER_DETAILS, username));

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GitHubUser>(content);
        }
    }
}
