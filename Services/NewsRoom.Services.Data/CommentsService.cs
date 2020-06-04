namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NewsRoom.Data.Common.Repositories;
    using NewsRoom.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int newsId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                NewsId = newsId,
                UserId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.NewsId).FirstOrDefault();
            return commentPostId == postId;
        }
    }
}
