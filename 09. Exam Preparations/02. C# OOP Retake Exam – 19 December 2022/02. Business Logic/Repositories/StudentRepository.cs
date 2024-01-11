using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        //Fields
        private List<IStudent> students;

        //Constructor
        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }

        //Properties
        public IReadOnlyCollection<IStudent> Models => this.students;

        //Methods
        public void AddModel(IStudent model) => students.Add(model);

        public IStudent FindById(int id) => students.FirstOrDefault(x => x.Id == id);   

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(" ");
            string firstName = fullName[0];
            string lastName = fullName[1];

            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
