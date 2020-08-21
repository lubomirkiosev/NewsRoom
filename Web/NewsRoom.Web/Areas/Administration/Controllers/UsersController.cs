namespace NewsRoom.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NewsRoom.Services.Data;
    using NewsRoom.Web.ViewModels.Administration.Dashboard.Users;

    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult All()
        {
            var model = this.usersService.All<UserViewModel>();
            return this.View(model);
        }
    }
}
