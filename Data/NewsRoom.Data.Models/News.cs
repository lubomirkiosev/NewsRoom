namespace NewsRoom.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NewsRoom.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        public News()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string SecondTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public bool Approved { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
