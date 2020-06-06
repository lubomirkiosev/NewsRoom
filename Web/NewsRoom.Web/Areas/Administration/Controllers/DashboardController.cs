namespace NewsRoom.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Administration.Dashboard;
    using NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel;

    public class DashboardController : AdministrationController
    {
        private readonly INewsService newsService;

        public DashboardController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                News = this.newsService.GetAll<IndexNewsForApprovalModel>().Where(x => x.Approved == false),
            };

            return this.View(viewModel);
        }
    }
}
