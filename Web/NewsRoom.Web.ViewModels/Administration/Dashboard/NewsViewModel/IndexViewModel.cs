namespace NewsRoom.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using NewsRoom.Web.ViewModels.Administration.Dashboard.NewsViewModel;

    public class IndexViewModel
    {
        public IEnumerable<IndexNewsForApprovalModel> News { get; set; }
    }
}
