namespace NewsRoom.Web.ViewModels.Home
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class HomeNewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 200
                    ? content.Substring(0, 200) + "..."
                    : content;
            }
        }
    }
}
