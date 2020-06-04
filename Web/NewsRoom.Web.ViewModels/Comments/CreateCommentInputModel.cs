namespace NewsRoom.Web.ViewModels.Comments
{
    using Ganss.XSS;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class CreateCommentInputModel : IMapFrom<Comment>
    {
        public int NewsId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
