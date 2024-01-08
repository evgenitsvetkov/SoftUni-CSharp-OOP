using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> users;

        public UserRepository()
        {
            this.users = new List<IUser>();
        }


        public void AddModel(IUser model)
        {
            this.users.Add(model);
        }

        public IUser FindById(string identifier)
        {
            var user = users.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);

            return user;
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return this.users;
        }

        public bool RemoveById(string identifier)
        {
            var user = this.FindById(identifier);

            return this.users.Remove(user);
        }
    }
}
