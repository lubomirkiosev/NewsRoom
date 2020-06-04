using NewsRoom.Web.ViewModels.NewsViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsRoom.Web.ViewModels
{
    public class SideBarNewsViewModels
    {
       public IEnumerable<NewsViewModel> News { get; set; }
    }
}
