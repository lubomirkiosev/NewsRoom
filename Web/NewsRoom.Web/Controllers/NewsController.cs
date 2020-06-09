namespace NewsRoom.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel;
    using NewsRoom.Web.ViewModels.NewsVieModels;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class NewsController : BaseController
    {
        private readonly INewsService newsService;
        private readonly ICategoryService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public NewsController(
            INewsService newsService,
            ICategoryService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.newsService = newsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var postViewModel = this.newsService.GetById<NewsViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new NewsCreateInputModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var newsId = await this.newsService.CreateAsync(input.Title, input.SecondTitle, input.Content, input.CategoryId, input.ImageUrl, user.Id);
            this.TempData["InfoMessage"] = "News created!";
            return this.RedirectToAction(nameof(this.ById), new { id = newsId });
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
            var newsId = this.newsService.Update(model.Id, model.Title, model.SecondTitle, model.Content, model.CategoryId, model.ImageUrl, model.Approved);
            return this.RedirectToAction(nameof(this.ById), new { id = newsId });
        }
    }
}
