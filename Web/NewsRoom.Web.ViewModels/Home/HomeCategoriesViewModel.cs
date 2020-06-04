namespace NewsRoom.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels.Categories;

    public class HomeCategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<NewsInCategoryViewModel> News { get; set; }
    }
}
