namespace NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using Ganss.XSS;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class IndexNewsForApprovalModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SecondTitle { get; set; }

        public string Content { get; set; }

        public string SanitizedShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 200
                    ? content.Substring(0, 200) + "..."
                    : content;
            }
        }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string AuthorId { get; set; }

        public bool Approved { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
