namespace NewsRoom.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Common;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Administration.Dashboard;
    using NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel;
    using NewsRoom.Web.ViewModels.Administration.Dashboard.Users;

    public class DashboardController : AdministrationController
    {
        private readonly INewsService newsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public DashboardController(
            INewsService newsService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.newsService = newsService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                News = this.newsService.GetAll<IndexNewsForApprovalModel>().Where(x => x.Approved == false),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> AddRole(string email)
        {
            var user = this.userManager.FindByEmailAsync(email);
            await this.userManager.AddToRoleAsync(user.Result, "Author");
            return this.RedirectToAction("Index");
        }
    }
}
