namespace NewsRoom.Web.ViewModels.NewsViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Ganss.XSS;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels.Comments;

    public class NewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SecondTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ImageUrl { get; set; }

        public string CategoryTitle { get; set; }

        public ApplicationUser Author { get; set; }

        public bool Approved { get; set; }

        public ICollection<CommentNewsViewModel> Comments { get; set; }
    }
}
