namespace NewsRoom.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NewsRoom.Web.ViewModels.Categories;

    public class NavBarModelView
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
