namespace NewsRoom.Web.ViewModels.NewsVieModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class NewsCreateInputModel : IMapTo<News>
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string SecondTitle { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
