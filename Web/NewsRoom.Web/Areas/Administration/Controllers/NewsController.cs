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

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = this.newsService.GetById<EditNewsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditNewsViewModel model)
        {
            this.newsService.Update(model.Id, model.Title, model.SecondTitle, model.Content, model.CategoryId, model.ImageUrl, model.Approved);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
