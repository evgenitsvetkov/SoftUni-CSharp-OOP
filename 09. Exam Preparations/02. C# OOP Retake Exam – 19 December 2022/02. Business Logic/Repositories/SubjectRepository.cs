using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        //Fields
        private List<ISubject> subjects;

        //Constructor
        public SubjectRepository()
        {
            this.subjects = new List<ISubject>();
        }

        //Properties
        public IReadOnlyCollection<ISubject> Models => this.subjects;

        //Methods
        public void AddModel(ISubject model) => subjects.Add(model);

        public ISubject FindById(int id) => subjects.FirstOrDefault(x => x.Id == id);

        public ISubject FindByName(string name) => subjects.FirstOrDefault(x => x.Name == name);
    }
}
