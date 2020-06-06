namespace NewsRoom.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Data.Common.Repositories;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class SidebarViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<News> newsRepository;

        public SidebarViewComponent(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new SideBarNewsViewModels
            {
                News = this.newsRepository.All().To<NewsViewModel>().OrderByDescending(x => x.CreatedOn).Take(5).ToList(),
            };
            return this.View(model);
        }
    }
}
