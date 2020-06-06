namespace NewsRoom.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NewsRoom.Web.ViewModels.NewsViewModels;

    public class SideBarNewsViewModels
    {
       public IEnumerable<NewsViewModel> News { get; set; }
    }
}
