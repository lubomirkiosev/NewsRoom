namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NewsRoom.Data.Common.Repositories;
    using NewsRoom.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IDeletableEntityRepository<Vote> votesRepository;

        public VotesService(IDeletableEntityRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public int GetVotes(int commentId)
        {
            var votes = this.votesRepository.All()
                .Where(x => x.CommentId == commentId).Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int commentId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.CommentId == commentId && x.UserId == userId);
            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    CommentId = commentId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
