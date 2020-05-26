namespace NewsRoom.Data.Models
{
    using NewsRoom.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Vote : BaseDeletableModel<int>
    {
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}