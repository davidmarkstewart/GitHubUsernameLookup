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
    public class GitHubRepositoryService
    {
        private const string GET_REPOSITORIES_BY_USERNAME_URL = "https://api.github.com/users/{0}/repos";

        public async Task<List<GitHubRepository>> GetRepositoriesByUsername(string username)
        {
            var restApiService = new RestApiService();

            var response = await restApiService.GetAsync(string.Format(GET_REPOSITORIES_BY_USERNAME_URL, username));

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<GitHubRepository>>(content)
                .OrderByDescending(x => x.StarGazerCount)
                .Take(5)
                .ToList();
        }
    }
}
