namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        //Fields
        public const double subjectRate = 1.3;

        //Constructor
        public TechnicalSubject(int id, string name)
            : base(id, name, subjectRate)
        {
        }
    }
}
