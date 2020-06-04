namespace NewsRoom.Web.ViewModels.NewsVieModels
{
    using System.Collections.Generic;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class NewsCreateInputModel : IMapTo<News>
    {
        public string Title { get; set; }

        public string SecondTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
