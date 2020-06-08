namespace NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;
    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class EditNewsViewModel : IMapFrom<News>, IMapTo<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SecondTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public bool Approved { get; set; }

        public string CategoryTitle { get; set; }
    }
}
