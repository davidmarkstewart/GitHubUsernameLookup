using GitHubUsernameLookup.Models;
using GitHubUsernameLookup.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GitHubUsernameLookup.Controllers
{
    public class HomeController : Controller
    {
        private readonly GitHubRepositoryService gitHubRepositoryService;
        private readonly GitHubUserService gitHubUserService;

        public HomeController()
        {
            gitHubRepositoryService = new GitHubRepositoryService();
            gitHubUserService = new GitHubUserService();
        }

        public ActionResult Index()
        {
            return View(new GitHubViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(GitHubViewModel vm)
        {
            vm = new GitHubViewModel
            {
                User = await BuildGitHubUserDetailsViewModel(vm.User.Username),
                Repositories = await BuildGitHubRepositoriesViewModel(vm.User.Username)
            };

            return View(vm);
        }

        private async Task<List<GitHubRepositoryViewModel>> BuildGitHubRepositoriesViewModel(string username)
        {
            var vm = new List<GitHubRepositoryViewModel>();

            var usersRepositories = await gitHubRepositoryService.GetRepositoriesByUsername(username);

            usersRepositories.ForEach(x => vm.Add(
                new GitHubRepositoryViewModel
                {
                    Name = x.Name,
                    StarGazerCount = x.StarGazerCount
                })
            );

            return vm;
        }

        private async Task<GitHubUserDetailsViewModel> BuildGitHubUserDetailsViewModel(string username)
        {
            var userDetails = await gitHubUserService.GetUserDetails(username);

            return new GitHubUserDetailsViewModel
            {
                Username = userDetails.Username,
                Avatar = userDetails.AvatarUrl,
                Location = userDetails.Location
            };
        }
    }
}