namespace NewsRoom.Web.ViewModels.NewsViewModels
{
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
