namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using NewsRoom.Data.Models;

    public interface INewsService
    {
        public IEnumerable<T> GetAll<T>();

        public Task<int> CreateAsync(string title, string secondTitle, string content, int categoryId, string imageUrl, string userId);

        public T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take, int skip = 0);

        int GetCountByCategoryId(int categoryId);
    }
}
