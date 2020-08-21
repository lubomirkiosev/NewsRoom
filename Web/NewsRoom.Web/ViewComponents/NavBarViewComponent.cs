namespace NewsRoom.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Data.Common.Repositories;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels;
    using NewsRoom.Web.ViewModels.Categories;

    public class NavBarViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public NavBarViewComponent(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new NavBarModelView
            {
                Categories = this.categoriesRepository.All().To<CategoryViewModel>().ToList(),
            };
            return this.View(model);
        }
    }
}
