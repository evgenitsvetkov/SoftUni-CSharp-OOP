using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        //Fields
        private List<IUniversity> universities;

        //Constructor
        public UniversityRepository()
        {
            this.universities = new List<IUniversity>();
        }

        //Properties
        public IReadOnlyCollection<IUniversity> Models => this.universities;

        //Methods
        public void AddModel(IUniversity model) => this.universities.Add(model);

        public IUniversity FindById(int id) => this.universities.FirstOrDefault(x => x.Id == id);

        public IUniversity FindByName(string name) => this.universities.FirstOrDefault(x => x.Name == name);
    }
}
