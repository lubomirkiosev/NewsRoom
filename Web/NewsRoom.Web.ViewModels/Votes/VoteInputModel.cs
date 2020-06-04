using NewsRoom.Data.Models;
using NewsRoom.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace NewsRoom.Web.ViewModels.Votes
{
    public class VoteInputModel : IMapTo<Vote>
    {
        public int CommentId { get; set; }

        [Required]
        public string UserId { get; set; }

        public bool Type { get; set; }
    }
}
