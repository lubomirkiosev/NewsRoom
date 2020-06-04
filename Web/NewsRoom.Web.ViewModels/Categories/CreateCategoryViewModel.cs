namespace NewsRoom.Web.ViewModels.Categories
{
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class CreateCategoryViewModel : IMapTo<Category>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
