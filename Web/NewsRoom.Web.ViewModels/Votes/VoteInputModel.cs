namespace NewsRoom.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class VoteInputModel : IMapTo<Vote>
    {
        public int CommentId { get; set; }

        [Required]
        public string UserId { get; set; }

        public bool Type { get; set; }
    }
}
