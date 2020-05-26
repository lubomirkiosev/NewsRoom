namespace NewsRoom.Data.Models
{
    using System.Collections.Generic;
    using System.Net.Mime;

    using NewsRoom.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Votes = new HashSet<Vote>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
