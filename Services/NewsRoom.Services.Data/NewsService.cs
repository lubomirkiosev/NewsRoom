namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    using NewsRoom.Data.Common.Repositories;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;

        public NewsService(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<int> CreateAsync(string title, string secondTitle, string content, int categoryId, string imageUrl, string userId)
        {
            var news = new News
            {
                CategoryId = categoryId,
                Content = content,
                Title = title,
                SecondTitle = secondTitle,
                ImageUrl = imageUrl,
                AuthorId = userId,
            };

            await this.newsRepository.AddAsync(news);
            await this.newsRepository.SaveChangesAsync();
            return news.Id;
        }

        public int Update(int id, string title, string secondTitle, string content, int categoryId, string imageUrl, bool approved)
        {
            var news = this.newsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);

            if (news == null)
            {
                throw new ArgumentException();
            }

            news.Title = title;
            news.SecondTitle = secondTitle;
            news.Content = content;
            news.ImageUrl = imageUrl;
            news.Approved = approved;
            this.newsRepository.Update(news);
            this.newsRepository.SaveChangesAsync();
            return news.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.newsRepository.All().To<T>().ToList();
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take, int skip = 0)
        {
            var query = this.newsRepository.All()
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var post = this.newsRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return post;
        }

        public int GetCountByCategoryId(int categoryId)
        {
            return this.newsRepository.All().Where(x => x.CategoryId == categoryId).Count();
        }
    }
}
