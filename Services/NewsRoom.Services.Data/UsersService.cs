namespace NewsRoom.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NewsRoom.Data.Common.Repositories;
    using NewsRoom.Data.Models;
    using NewsRoom.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IEnumerable<T> All<T>()
        {
            return this.usersRepository.All().To<T>().ToList();
        }
    }
}
