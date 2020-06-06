namespace NewsRoom.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class NewsController : AdministrationController
    {
        private readonly INewsService newsService;
        private readonly ICategoryService categoriesService;

        public NewsController(INewsService newsService, ICategoryService categoriesService)
        {
            this.newsService = newsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Edit()
        {
            var viewModel = this.newsService.GetById<EditNewsViewModel>(26);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditNewsViewModel model)
        {
            return this.RedirectToAction();
        }
    }
}
