namespace NewsRoom.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Categories;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class CategoriesController : BaseController
    {
        private const int ItemsPerPage = 5;

        private readonly INewsService newsService;
        private readonly ICategoryService categoriesService;

        public CategoriesController(INewsService newsService, ICategoryService categoriesService)
        {
            this.newsService = newsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryViewModel input)
        {
            var categoryId = await this.categoriesService.CreateAsync(input.Title, input.Description, input.ImageUrl);
            this.TempData["InfoMessage"] = "Category created!";
            return this.RedirectToAction(nameof(this.ById), new { id = categoryId });
        }

        public IActionResult ById(int id)
        {
            var viewModel = this.categoriesService.GetAll<CategoryViewModel>().FirstOrDefault(x => x.Id == id);
            return this.View(viewModel);
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel =
               this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.NewsPerPage = this.newsService.GetByCategoryId<NewsInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.newsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
