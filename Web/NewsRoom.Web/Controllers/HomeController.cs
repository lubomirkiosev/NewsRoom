﻿namespace NewsRoom.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels;
    using NewsRoom.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly INewsService newsService;
        private readonly ICategoryService categoryService;

        public HomeController(INewsService newsService, ICategoryService categoryService)
        {
            this.newsService = newsService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var viewModel = this.categoryService.GetAll<HomeCategoriesViewModel>();
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
