namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int commentId, string userId, bool isUpVote);

        int GetVotes(int postId);
    }
}
