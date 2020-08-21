namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUsersService
    {
        public IEnumerable<T> All<T>();
    }
}
