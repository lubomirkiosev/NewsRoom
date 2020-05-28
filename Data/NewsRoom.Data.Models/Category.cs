namespace NewsRoom.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;

    using NewsRoom.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<News> News { get; set; }
    }
}
