using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubUsernameLookup.Models
{
    public class GitHubViewModel
    {
        public GitHubViewModel()
        {
            Repositories = new List<GitHubRepositoryViewModel>();
        }

        public GitHubUserDetailsViewModel User { get; set; }
        public List<GitHubRepositoryViewModel> Repositories { get; set; }
    }
}