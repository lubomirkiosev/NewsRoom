namespace NewsRoom.Web.ViewModels.Administration.Dashboard.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsNotAdded { get; set; }

        public string RoleName { get; set; }
    }
}
