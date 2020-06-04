namespace NewsRoom.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<NewsInCategoryViewModel> NewsPerPage { get; set; }
    }
}
