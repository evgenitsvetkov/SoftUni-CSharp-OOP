namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        //Fields
        public const double subjectRate = 1.0;

        //Constructor
        public EconomicalSubject(int id, string name)
            : base(id, name, subjectRate)
        {
        }
    }
}
