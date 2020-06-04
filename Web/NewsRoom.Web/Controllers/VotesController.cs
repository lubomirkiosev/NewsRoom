namespace NewsRoom.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Votes;

    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(model.CommentId, userId, model.Type);
            var votes = this.votesService.GetVotes(model.CommentId);
            return this.Redirect($"/News/ById/26");
        }
    }
}
