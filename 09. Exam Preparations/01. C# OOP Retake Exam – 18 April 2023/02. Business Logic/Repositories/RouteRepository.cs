using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        public readonly List<IRoute> routes;

        public RouteRepository()
        {
            this.routes = new List<IRoute>();
        }

        public void AddModel(IRoute model)
        {
            this.routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            var route = routes.FirstOrDefault(x => x.RouteId == int.Parse(identifier));

            return route;
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return this.routes;
        }

        public bool RemoveById(string identifier)
        {
            var route = this.FindById(identifier);

            return this.routes.Remove(route);
        }
    }
}
