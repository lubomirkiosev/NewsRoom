namespace NewsRoom.Web.ViewModels.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using Ganss.XSS;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class CommentNewsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }

        public int NewsId { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentNewsViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
